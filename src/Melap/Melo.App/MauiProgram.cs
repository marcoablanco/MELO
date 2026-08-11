namespace Melo.App;

using Melo.Logic.AppConfiguration;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseFonts()
			.RegisterServices()
			.RegisterFeatures();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder UseFonts(this MauiAppBuilder builder)
	{
		builder.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});

		return builder;
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		AppBootstrapper.InitAppLogic(builder.Services);
		return builder;
	}

	public static MauiAppBuilder RegisterFeatures(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransient<AppShell>();

		return builder;
	}
}