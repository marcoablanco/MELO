namespace Melo.Logic.Tests;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;

public abstract class BaseService
{
	protected IServiceProvider ServiceProvider { get; }

	protected BaseService()
	{
		var services = new ServiceCollection();
		services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
		ConfigureServices(services);
		ServiceProvider = services.BuildServiceProvider();
	}

	protected virtual void ConfigureServices(IServiceCollection services)
	{
	}
}

