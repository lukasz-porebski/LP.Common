using System.Linq.Expressions;
using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;

namespace LP.Common.Application.Contracts.Interfaces;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : BaseAggregateRoot
{
    Task<TAggregateRoot?> GetAsync(AggregateId id, CancellationToken cancellationToken);
    Task<TAggregateRoot?> GetAsync(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);

    Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken);

    Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);
    Task<IReadOnlyDictionary<AggregateId, bool>> ExistsAsync(IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken);
    Task PersistAsync(IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true);
    Task PersistAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true);
    Task RemoveAsync(IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true);
    Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true);
    Task SaveAsync(CancellationToken cancellationToken);
}