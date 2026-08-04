using Krosoft.Extensions.Blocking.Abstractions.Models;
using Krosoft.Extensions.Blocking.Redis.Providers;

namespace Krosoft.Extensions.Blocking.Redis.Extensions;

public static class KrosoftBlockingOptionsExtensions
{
    public static KrosoftBlockingOptions UseRedisStorage(this KrosoftBlockingOptions options)
        => options.UseStorage(new RedisBlockingStorageProvider());
}
