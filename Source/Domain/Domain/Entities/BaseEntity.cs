using LP.Common.Domain.Interfaces;
using LP.Common.Domain.ValueObjects;

namespace LP.Common.Domain.Entities;

public abstract class BaseEntity(AggregateId id, EntityNo no) : BaseEntityCore(id), IUpdateableEntity
{
    protected BaseEntity() : this(null!, null!)
    {
    }

    public EntityNo No { get; private set; } = no;
}