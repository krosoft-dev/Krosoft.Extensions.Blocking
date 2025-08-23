using Krosoft.Extensions.Identity.Abstractions.Interfaces;

namespace Krosoft.Extensions.Blocking.Tests.Core;

internal class FakeProvider : IIdentifierProvider, IAccessTokenProvider
{
    public Task<string?> GetIdentifierAsync(CancellationToken cancellationToken) => Task.FromResult("Hello")!;
 
    public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken) => Task.FromResult("Hello")!;
}