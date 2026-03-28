namespace LP.Common.Infrastructure.Endpoints.Requests;

public record PaginationRequest(
    int PageNumber,
    int PageSize,
    SortRequest? Sort,
    string? Search
);