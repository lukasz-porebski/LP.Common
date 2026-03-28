namespace LP.Common.Infrastructure.Endpoints.Requests;

public record EntityPersistRequest<T>(int? No, T Data)
    where T : class;