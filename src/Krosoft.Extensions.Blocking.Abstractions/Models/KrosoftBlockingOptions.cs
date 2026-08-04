using Krosoft.Extensions.Blocking.Abstractions.Interfaces;

namespace Krosoft.Extensions.Blocking.Abstractions.Models;

/// <summary>
///     Options de configuration du blocage de connexion.
/// </summary>
public sealed class KrosoftBlockingOptions
{
    /// <summary>
    ///     Provider de stockage des éléments bloqués.
    /// </summary>
    public IBlockingStorageProvider? StorageProvider { get; set; }

    /// <summary>
    ///     Configure un provider de stockage personnalisé.
    /// </summary>
    public KrosoftBlockingOptions UseStorage(IBlockingStorageProvider storageProvider)
    {
        StorageProvider = storageProvider ?? throw new ArgumentNullException(nameof(storageProvider));
        return this;
    }
}
