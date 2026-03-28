using LP.Common.Domain.ValueObjects;

namespace LP.Common.Domain.Entities;

public abstract class BaseEntityCore(AggregateId id)
{
    protected BaseEntityCore() : this(null!)
    {
    }

    public AggregateId Id { get; private set; } = id;
}