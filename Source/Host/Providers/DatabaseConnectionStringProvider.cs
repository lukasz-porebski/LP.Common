using LP.Common.Host.AppSettings;
using LP.Common.Host.Extensions;
using LP.Common.Infrastructure.ReadModels.Dapper;
using LP.Common.Shared.Attributes;
using Microsoft.Extensions.Configuration;

namespace LP.Common.Host.Providers;

[Provider]
public class DatabaseConnectionStringProvider(IConfiguration configuration) : IDatabaseConnectionStringProvider
{
    public string Get()
    {
        return configuration.GetOptions(BaseAppSettingsSections.Database).ConnectionString;
    }
}