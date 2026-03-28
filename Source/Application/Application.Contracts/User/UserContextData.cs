using LP.Common.Domain.ValueObjects;

namespace LP.Common.Application.Contracts.User;

public record UserContextData(
    AggregateId UserId
);