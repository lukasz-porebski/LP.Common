using LP.Common.Identity.Interfaces;

namespace LP.Common.Host.AppSettings.Sections;

public class IdentitySettings : IIdentityConfiguration
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string AccessTokenSecretKey { get; set; } = null!;
    public int AccessTokenExpirationMinutes { get; set; }
    public string RefreshTokenSalt { get; set; } = null!;
    public int RefreshTokenExpirationDays { get; set; }
}