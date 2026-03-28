using LP.Common.Shared.Attributes;
using LP.Common.Shared.Providers;

namespace LP.Common.Host.Providers;

[Provider]
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now() =>
        DateTime.UtcNow;
}