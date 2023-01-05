using Pages;

namespace BusApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		
		Routing.RegisterRoute("./Pages/DriverManagementPage", typeof(DriverManagementPage));
		Routing.RegisterRoute(nameof(FindBusPage), typeof(FindBusPage));
		Routing.RegisterRoute(nameof(RouteDetailsPage), typeof(RouteDetailsPage));
        InitializeComponent();

    }
}
