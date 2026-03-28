using LP.Common.Domain.ValueObjects;

namespace LP.Common.Infrastructure.ReadModels.Dapper.Data;

public record GetByIdData
{
    public GetByIdData(AggregateId id, AggregateId userId)
    {
        Id = id.ToString();
        UserId = userId.ToString();
    }

    public string Id { get; }
    public string UserId { get; }
};