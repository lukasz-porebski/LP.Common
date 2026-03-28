using LP.Common.Domain.Entities;
using LP.Common.Infrastructure.Database.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LP.Common.Infrastructure.Database.EF.Configurations;

public abstract class BaseEntityCoreConfiguration<TEntity>(params string[] entityKeys) : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntityCore
{
    protected IReadOnlyCollection<string> EntityKeys { get; } = entityKeys;
    
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var keys = new List<string>([nameof(BaseAggregateRoot.Id)]);
        keys.AddRange(entityKeys);

        builder.HasKey(keys.ToArray());

        builder.ConfigureAggregateRootId();
    }
}