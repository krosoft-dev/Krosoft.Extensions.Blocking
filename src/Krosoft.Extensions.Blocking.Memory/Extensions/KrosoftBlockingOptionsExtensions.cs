using Krosoft.Extensions.Blocking.Abstractions.Models;
using Krosoft.Extensions.Blocking.Memory.Providers;

namespace Krosoft.Extensions.Blocking.Memory.Extensions;

public static class KrosoftBlockingOptionsExtensions
{
    public static KrosoftBlockingOptions UseMemoryStorage(this KrosoftBlockingOptions options)
        => options.UseStorage(new MemoryBlockingStorageProvider());
}
