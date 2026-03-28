using LP.Common.Domain.ValueObjects;

namespace LP.Common.Domain.Extensions;

public static class StringExtensions
{
    public static AggregateId ToAggregateId(this string source) =>
        new(source);
}