using LP.Common.Identity.Models;

namespace LP.Common.Identity.Interfaces;

public interface IIdentityService
{
    Task<AuthenticateResponse> AuthenticateByCredentialsAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<AuthenticateResponse> AuthenticateByRefreshTokenAsync(string token, CancellationToken cancellationToken);
}