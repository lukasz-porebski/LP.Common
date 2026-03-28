using System.Reflection;
using System.Windows.Input;
using LP.Common.Application.CQRS;
using LP.Common.Domain.Contracts;
using LP.Common.Domain.Entities;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Infrastructure.Endpoints;
using LP.Common.Infrastructure.Integration;
using LP.Common.Infrastructure.ReadModels.Dapper;

namespace LP.Common.Host;

public class CommonAssemblies : BaseAssemblies
{
    public override Assembly Application => typeof(ICommandHandler<>).Assembly;
    public override Assembly ApplicationContracts => typeof(ICommand).Assembly;
    public override Assembly Domain => typeof(BaseAggregateRoot).Assembly;
    public override Assembly DomainContracts => typeof(Marker).Assembly;
    public override Assembly? Infrastructure => null;
    public override Assembly InfrastructureDatabaseEf => typeof(BaseDbContext).Assembly;
    public override Assembly InfrastructureEndpoints => typeof(BaseController).Assembly;
    public override IReadOnlyCollection<Assembly> InfrastructureIntegrations => [typeof(BaseApi).Assembly];
    public override Assembly InfrastructureReadModels => typeof(IDatabaseConnectionStringProvider).Assembly;
    public override Assembly Host => typeof(BaseAssemblies).Assembly;
}