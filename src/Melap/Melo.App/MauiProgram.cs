namespace Melo.App;

using AppConfiguration;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		return MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.Configure()
			.Build();
	}
}