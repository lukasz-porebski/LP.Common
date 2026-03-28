using Newtonsoft.Json;

namespace LP.Common.Identity.Models;

public record AuthenticateResponse(
    string UserId,
    string AccessToken,
    [property: JsonIgnore] string RefreshToken,
    [property: JsonIgnore] DateTime RefreshTokenExpiredAt
);