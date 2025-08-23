﻿using JetBrains.Annotations;
using Krosoft.Extensions.Blocking.Abstractions.Interfaces;
using Krosoft.Extensions.Blocking.Extensions;
using Krosoft.Extensions.Blocking.Memory.Extensions;
using Krosoft.Extensions.Blocking.Services;
using Krosoft.Extensions.Testing;
using Krosoft.Extensions.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Blocking.Tests.Services;

[TestClass]
[TestSubject(typeof(IpBlockingService))]
public class IpBlockingServiceTests : BaseTest
{
    private IIpBlockingService _ipBlockingService = null!;

    protected override void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddBlocking()
                .AddMemoryBlockingStorage()
                .SwapTransient(_ => new Mock<ILogger<IpBlockingService>>().Object);
    }

    [TestMethod]
    public async Task BlockAsync_Ok()
    {
        var remoteIp = "test";
        await _ipBlockingService.BlockAsync(remoteIp, CancellationToken.None);
        var isBlocked = await _ipBlockingService.IsBlockedAsync(remoteIp, CancellationToken.None);

        Check.That(isBlocked).IsTrue();
    }

    [TestInitialize]
    public void SetUp()
    {
        var serviceProvider = CreateServiceCollection();
        _ipBlockingService = serviceProvider.GetRequiredService<IIpBlockingService>();
    }
}