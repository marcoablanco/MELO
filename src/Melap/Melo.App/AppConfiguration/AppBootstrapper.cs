namespace Melo.App.AppConfiguration;

using Features.Home;
using Melo.Logic.AppConfiguration;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public static class AppBootstrapper
{
	public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder builder)
	{
		builder.Services
			.InitAppLogic()
			.RegisterFeatures();

		return builder;
	}

	private static IServiceCollection RegisterFeatures(this IServiceCollection services)
	{
		return services
			.AddTransient<AppShell>()
			.AddHome();
	}

	private static IServiceCollection AddHome(this IServiceCollection services)
	{
		return services
			.AddTransient<HomePage>()
			.AddTransient<HomeViewModel>();
	}
}

