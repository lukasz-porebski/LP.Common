using LP.Common.Domain.ValueObjects;

namespace LP.Common.Domain.Interfaces;

public interface IPersistableEntity
{
    EntityNo? No { get; }
}