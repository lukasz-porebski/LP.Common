using LP.Common.Domain.ValueObjects;

namespace LP.Common.Identity.EF.Interfaces;

public interface IPermissionService
{
    Task<IReadOnlySet<string>> GetUserPermissionsAsync(AggregateId id, CancellationToken cancellationToken);
}