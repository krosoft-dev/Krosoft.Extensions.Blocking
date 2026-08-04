using Krosoft.Extensions.Blocking.Abstractions.Interfaces;
using Krosoft.Extensions.Blocking.Redis.Services;
using Krosoft.Extensions.Cache.Distributed.Redis.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Krosoft.Extensions.Blocking.Redis.Providers;

/// <summary>
///     Provider de stockage Redis pour le blocage de connexion, partagé par toutes les instances de l'application.
/// </summary>
public class RedisBlockingStorageProvider : IBlockingStorageProvider
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddDistributedCacheExt();
        services.AddTransient<IBlockingStorage, RedisBlockingStorage>();
    }
}
