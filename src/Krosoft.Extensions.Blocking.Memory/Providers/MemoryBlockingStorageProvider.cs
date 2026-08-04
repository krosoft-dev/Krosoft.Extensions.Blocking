using Krosoft.Extensions.Blocking.Abstractions.Interfaces;
using Krosoft.Extensions.Blocking.Memory.Services;
using Krosoft.Extensions.Cache.Memory.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Krosoft.Extensions.Blocking.Memory.Providers;

/// <summary>
///     Provider de stockage mémoire pour le blocage de connexion.
/// </summary>
public class MemoryBlockingStorageProvider : IBlockingStorageProvider
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddMemoryCacheExt();
        services.AddTransient<IBlockingStorage, MemoryBlockingStorage>();
    }
}
