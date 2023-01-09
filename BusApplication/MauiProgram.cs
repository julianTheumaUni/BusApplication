using BusApplication.Repositories;
using BusApplication.ViewModel;
using Pages;

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

        builder.Services.AddSingleton<BusRepository>(s => ActivatorUtilities.CreateInstance<BusRepository>(s, dbPath));
		
        builder.Services.AddSingleton<RouteRepository>(s => ActivatorUtilities.CreateInstance<RouteRepository>(s, dbPath));
        builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, dbPath));
        builder.Services.AddSingleton<PaymentsRepository>(s => ActivatorUtilities.CreateInstance<PaymentsRepository>(s, dbPath));
        builder.Services.AddSingleton<BusUserRepository>(s => ActivatorUtilities.CreateInstance<BusUserRepository>(s, dbPath));
        builder.Services.AddSingleton<BusStopRepository>(s => ActivatorUtilities.CreateInstance<BusStopRepository>(s, dbPath));
        builder.Services.AddSingleton<BusLogsRepository>(s => ActivatorUtilities.CreateInstance<BusLogsRepository>(s, dbPath));
        builder.Services.AddSingleton<BusStopRoutesRepository>(s => ActivatorUtilities.CreateInstance<BusStopRoutesRepository>(s, dbPath));
        builder.Services.AddSingleton<ArrivalsRepository>(s => ActivatorUtilities.CreateInstance<ArrivalsRepository>(s, dbPath));


        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<DriverManagementPage>();
		builder.Services.AddTransient<DriverManagementViewModel>();

        builder.Services.AddTransient<UserManagementPage>();
        builder.Services.AddTransient<UserManagementViewModel>();

        builder.Services.AddTransient<FleetManagementPage>();
        builder.Services.AddTransient<FleetManagementViewModel>();

        builder.Services.AddSingleton<AddBusUserPage>();

        builder.Services.AddSingleton<FindBusPage>();
		builder.Services.AddSingleton<FindBusViewModel>();

		builder.Services.AddSingleton<RouteDetailsPage>();
		builder.Services.AddSingleton<RouteDetailsViewModel>();

        builder.Services.AddSingleton<ViewDriverPage>();

        builder.Services.AddSingleton<AddDriverPage>();

        builder.Services.AddSingleton<UpdateDriverPage>();

        builder.Services.AddSingleton<DeleteDriverPage>();

		builder.Services.AddSingleton<BusLocationPage>();
		builder.Services.AddSingleton<BusLocationViewModel>();
        /*
		 *Transient is created and destroyed each time, useful for dynamic content
		 *Singleton is created once and not destroyed
		 */
        return builder.Build();
	}
}
