using LP.Common.Domain.Entities;

namespace LP.Common.Application.Contracts.Interfaces;

public interface IReadonlyDatabase
{
    IQueryable<T> AggregateRoot<T>()
        where T : BaseAggregateRoot;

    IQueryable<T> Entity<T>()
        where T : BaseEntityCore;

    Task<T[]> MaterializeAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken);
}