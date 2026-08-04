using Krosoft.Extensions.Blocking.Abstractions.Interfaces;
using Krosoft.Extensions.Blocking.Abstractions.Models;
using Krosoft.Extensions.Blocking.Services;
using Krosoft.Extensions.Core.Models.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Krosoft.Extensions.Blocking.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Ajoute les blocages par access token, par identifiant et par IP.
    /// </summary>
    public static IServiceCollection AddBlocking(this IServiceCollection services,
                                                 Action<KrosoftBlockingOptions> action)
    {
        services.AddBlockingStorage(action);

        services.AddSingleton<IAccessTokenBlockingService, AccessTokenBlockingService>();
        services.AddSingleton<IIdentifierBlockingService, IdentifierBlockingService>();
        services.AddSingleton<IIpBlockingService, IpBlockingService>();

        return services;
    }

    /// <summary>
    ///     Ajoute uniquement le stockage configuré, sans les services de blocage.
    ///     Destiné aux packages qui n'exposent qu'une partie des blocages.
    /// </summary>
    public static IServiceCollection AddBlockingStorage(this IServiceCollection services,
                                                        Action<KrosoftBlockingOptions> action)
    {
        var options = new KrosoftBlockingOptions();
        action(options);

        if (options.StorageProvider == null)
        {
            throw new KrosoftTechnicalException("Un provider de stockage doit être configuré.");
        }

        options.StorageProvider.RegisterServices(services);

        return services;
    }
}
