using LP.Common.Application.Contracts.CQRS;
using LP.Common.Application.Contracts.Interfaces;
using LP.Common.Application.CQRS;
using LP.Common.Host.Attributes;
using LP.Common.Host.Extensions;
using LP.Common.Infrastructure.ReadModels.Dapper;
using LP.Common.Shared.Attributes;
using RestSharp.Extensions;

namespace LP.Common.Host.Utils;

public static class TypeRecognizer
{
    public static bool IsRecord(this Type source) =>
        source.IsClass && source.GetMethods().Any(m => m.Name == "<Clone>$");

    public static bool IsCommand(this Type source) =>
        source.Implements<ICommand>();

    public static bool IsQuery(this Type source) =>
        source.ImplementsGeneric(typeof(IQuery<>));

    public static bool IsCommandHandler(this Type source) =>
        source.ImplementsGeneric(typeof(ICommandHandler<>));

    public static bool IsQueryHandler(this Type source) =>
        source.ImplementsGeneric(typeof(IQueryHandler<,>));

    public static bool IsRepository(this Type source) =>
        source.IsRegistrable() && source.ImplementsGeneric(typeof(IRepository<>));

    public static bool IsService(this Type source) =>
        source.IsRegistrable() && source.GetAttribute<ServiceAttribute>() != null;

    public static bool IsProvider(this Type source) =>
        source.IsRegistrable() && source.GetAttribute<ProviderAttribute>() != null;

    public static bool IsFactory(this Type source) =>
        source.IsRegistrable() && source.GetAttribute<FactoryAttribute>() != null;

    public static bool IsReadModel(this Type source) =>
        source.IsSubclassOf(typeof(BaseReadModel));

    public static bool IsSeeder(this Type source) =>
        source.IsRegistrable() && source.GetAttribute<SeederAttribute>() != null;
}