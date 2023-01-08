using BusApplication.Repositories;
using Pages;
using System.Diagnostics.Contracts;
using System.Windows;

namespace BusApplication;

public partial class App : Application
{
	public static DriverRepository DriverRepo { get; private set; }
	public static BusRepository BusRepo { get; private set; }
	public static RouteRepository RouteRepo { get; private set; }
	public string Tab1Text { get; set; }

	public App(DriverRepository driverRepository, BusRepository busRepository, RouteRepository routeRepository)
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

        InitializeComponent();

		//MainPage = new AppShell();
		DriverRepo= driverRepository;
		BusRepo = busRepository;
		RouteRepo = routeRepository;
	}
}
