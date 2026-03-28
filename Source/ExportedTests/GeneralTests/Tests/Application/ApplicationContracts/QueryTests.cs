using LP.Common.Application.CQRS;
using LP.Common.Host.Utils;
using Xunit;

namespace LP.Common.GeneralTests.Tests;

public partial class BaseGeneralTests
{
    [Fact]
    public void QueryName_Should_EndWithQueryWord()
    {
        AssertInvalid(GetQueryTypes(), t => !t.Name.EndsWith("Query", StringComparison.Ordinal));
    }

    [Fact]
    public void Query_Should_ExistsOnlyInApplicationContractsProject()
    {
        AssertInvalid(assemblies.GetAllTypes(excludeApplicationContracts: true), t => t.IsQuery());
    }

    [Fact]
    public void Query_Should_BeRecord()
    {
        AssertInvalid(GetQueryTypes(), t => !t.IsRecord());
    }

    [Fact]
    public void Query_Should_BePublic()
    {
        AssertInvalid(GetQueryTypes(), t => t.IsNotPublic);
    }

    [Fact]
    public void Query_Should_HasHandler()
    {
        AssertDeclarationHasImplementation(GetQueryTypes(), GetQueryHandlerTypes(), typeof(IQueryHandler<,>));
    }

    [Fact]
    public void Query_Should_HasExactlyOneHandler()
    {
        AssertNumberOfDeclarationsAndImplementationsAreSame(GetQueryTypes(), GetQueryHandlerTypes());
    }

    private IEnumerable<Type> GetQueryTypes() =>
        assemblies.ApplicationContracts.GetTypes().Where(t => t.IsQuery());
}