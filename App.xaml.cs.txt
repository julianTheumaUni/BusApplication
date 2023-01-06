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

        InitializeComponent();

		//MainPage = new AppShell();
		DriverRepo= driverRepository;
		BusRepo = busRepository;


	}
}