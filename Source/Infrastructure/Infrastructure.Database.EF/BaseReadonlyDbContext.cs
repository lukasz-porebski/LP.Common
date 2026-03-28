using LP.Common.Application.Contracts.Interfaces;
using LP.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LP.Common.Infrastructure.Database.EF;

public abstract class BaseReadonlyDbContext<TDbContext>(TDbContext context) : IReadonlyDatabase
    where TDbContext : BaseDbContext
{
    public IQueryable<T> AggregateRoot<T>() where T : BaseAggregateRoot =>
        Set<T>();

    public IQueryable<T> Entity<T>() where T : BaseEntityCore =>
        Set<T>();

    public Task<T[]> MaterializeAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken) =>
        queryable.ToArrayAsync(cancellationToken);

    private IQueryable<T> Set<T>()
        where T : class =>
        context.Set<T>().AsNoTracking();
}