using BusApplication.Repositories;
using BusApplication.ViewModel;
using ViewModel;

namespace BusApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
        builder.Services.AddSingleton<DriverRepository>(s => ActivatorUtilities.CreateInstance<DriverRepository>(s, dbPath));
        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<DriverManagementPage>();
		builder.Services.AddTransient<DriverManagementViewModel>();

		builder.Services.AddSingleton<FindBusPage>();
		builder.Services.AddTransient<FindBusViewModel>();
		/*
		 *Transient is created and destroyed each time, useful for dynamic content
		 *Singleton is created once and not destroyed
		 */
        return builder.Build();
	}
}
