namespace Melo.App.AppConfiguration;

using Features.Home;
using Features.QueryHistory;
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
			   .AddTransient(s => new AppShell())
			   .AddHome()
			   .AddQueryHistory();
	}

	private static IServiceCollection AddHome(this IServiceCollection services)
	{
		return services
			   .AddTransient(s => new HomePage(s))
			   .AddTransient(s => new HomeViewModel(s));
	}

	private static IServiceCollection AddQueryHistory(this IServiceCollection services)
	{
		return services
			   .AddSingleton<IQueryHistoryService>(s => new QueryHistoryService(s))
			   .AddTransient(s => new QueryHistoryPage(s))
			   .AddTransient(s => new QueryHistoryViewModel(s));
	}
}