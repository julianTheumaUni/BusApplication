using BusApplication.Repositories;
using Pages;
using System.Diagnostics.Contracts;
using System.Windows;

namespace BusApplication;

public partial class App : Application
{
	public static DriverRepository DriverRepo { get; private set; }
	public string Tab1Text { get; set; }

	public App(DriverRepository driverRepository)
	{
		Tab1Text = "Admin";
		Routing.RegisterRoute(nameof(DriverManagementPage), typeof(DriverManagementPage));
		Routing.RegisterRoute(nameof(FindBusPage), typeof(FindBusPage));
        Routing.RegisterRoute(nameof(RouteDetailsPage), typeof(RouteDetailsPage));
		Routing.RegisterRoute(nameof(ViewDriverPage), typeof(ViewDriverPage));
        Routing.RegisterRoute(nameof(AddDriverPage), typeof(AddDriverPage));
        Routing.RegisterRoute(nameof(UpdateDriverPage), typeof(UpdateDriverPage));
        Routing.RegisterRoute(nameof(DeleteDriverPage), typeof(DeleteDriverPage));

        InitializeComponent();

		//MainPage = new AppShell();
		DriverRepo= driverRepository;
		BusRepo = busRepository;


	}
}
