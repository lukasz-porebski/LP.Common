using LP.Common.Domain.Attributes;

namespace LP.Common.Domain.ValueObjects;

[ValueObject]
public record AggregateStateChangeInfo(AggregateId? UserId, DateTime At)
{
    public static AggregateStateChangeInfo Empty =>
        new(null, new DateTime());

    public bool IsEmpty =>
        Equals(Empty);
}