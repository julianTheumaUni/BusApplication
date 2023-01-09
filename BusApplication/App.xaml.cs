using BusApplication.Repositories;
using Pages;
using System.Diagnostics.Contracts;
using System.Windows;

namespace BusApplication;

public partial class App : Application
{
	public static ArrivalsRepository ArrivalsRepo { get; private set; }
	public static BusLogsRepository BusLogsRepo { get; private set; }
	public static BusRepository BusRepo { get; private set; }
	public static BusStopRepository BusStopRepo { get; private set; }
	public static BusStopRoutesRepository BusStopRoutesRepo { get; private set; }
	public static BusUserRepository BusUserRepo { get; private set; }
    public static DriverRepository DriverRepo { get; private set; }
    public static PaymentsRepository PaymentsRepo { get; private set; }
    public static UserRepository UserRepo { get; private set; }
	public static RouteRepository RouteRepo { get; private set; }
	public string Tab1Text { get; set; }

	public App(
			ArrivalsRepository arrivalsRepository, 
			BusLogsRepository busLogsRepository, 
			BusRepository busRepository, 
			BusStopRepository busStopRepository, 
			BusStopRoutesRepository busStopRoutesRepository,
			BusUserRepository busUserRepository,
			DriverRepository driverRepository,
			PaymentsRepository paymentsRepository,
			UserRepository userRepository,
			RouteRepository routeRepository)
	{
		Tab1Text = "Admin";
		Routing.RegisterRoute(nameof(DriverManagementPage), typeof(DriverManagementPage));
		Routing.RegisterRoute(nameof(FindBusPage), typeof(FindBusPage));
        Routing.RegisterRoute(nameof(RouteDetailsPage), typeof(RouteDetailsPage));
		Routing.RegisterRoute(nameof(ViewDriverPage), typeof(ViewDriverPage));
        Routing.RegisterRoute(nameof(AddDriverPage), typeof(AddDriverPage));
        Routing.RegisterRoute(nameof(UpdateDriverPage), typeof(UpdateDriverPage));
        Routing.RegisterRoute(nameof(DeleteDriverPage), typeof(DeleteDriverPage));
        Routing.RegisterRoute(nameof(UserManagementPage), typeof(UserManagementPage));
        Routing.RegisterRoute(nameof(FleetManagementPage), typeof(FleetManagementPage));
        Routing.RegisterRoute(nameof(BusLocationPage), typeof(BusLocationPage));

        InitializeComponent();

		//MainPage = new AppShell();
		ArrivalsRepo = arrivalsRepository;
		BusLogsRepo = busLogsRepository;
		BusRepo = busRepository;
		BusStopRepo = busStopRepository;
		BusStopRoutesRepo = busStopRoutesRepository;
		BusUserRepo= busUserRepository;
		DriverRepo= driverRepository;
		PaymentsRepo= paymentsRepository;
		UserRepo= userRepository;
		RouteRepo = routeRepository;
	}
}
