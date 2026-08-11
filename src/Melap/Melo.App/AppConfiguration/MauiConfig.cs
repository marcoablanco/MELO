namespace Melo.App.AppConfiguration;

using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Builder;
using ReactiveUI.Maui;
using Splat;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public static class MauiConfig
{
	public static MauiAppBuilder Configure(this MauiAppBuilder builder)
	{
		builder
			.SetFonts()
			.SetRxUI()
			.RegisterDependencies();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder;
	}

	private static MauiAppBuilder SetFonts(this MauiAppBuilder builder)
	{
		builder.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});

		return builder;
	}

	private static MauiAppBuilder SetRxUI(this MauiAppBuilder builder)
	{

		builder.UseReactiveUI(rxBuilder =>
		{
			rxBuilder.WithMaui()
					 .WithMauiScheduler()
					 .WithRegistration(resolver => resolver.Register<IActivationForViewFetcher>(() => new ActivationForViewFetcher()));
		});

		return builder;
	}
}