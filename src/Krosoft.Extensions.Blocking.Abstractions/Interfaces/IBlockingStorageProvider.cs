using Microsoft.Extensions.DependencyInjection;

namespace Krosoft.Extensions.Blocking.Abstractions.Interfaces;

/// <summary>
///     Interface pour définir un provider de stockage de blocage.
/// </summary>
public interface IBlockingStorageProvider
{
    /// <summary>
    ///     Enregistre le <see cref="IBlockingStorage" /> et les services dont il dépend.
    /// </summary>
    /// <param name="services">Collection de services.</param>
    void RegisterServices(IServiceCollection services);
}
