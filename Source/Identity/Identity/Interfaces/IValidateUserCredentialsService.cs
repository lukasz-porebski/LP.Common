using LP.Common.Domain.ValueObjects;

namespace LP.Common.Identity.Interfaces;

public interface IValidateUserCredentialsService
{
    Task<AggregateId> ValidateAndThrow(string email, string password, CancellationToken cancellationToken);
}