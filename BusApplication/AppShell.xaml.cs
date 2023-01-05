using Pages;

namespace BusApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		
		Routing.RegisterRoute("./Pages/DriverManagementPage", typeof(DriverManagementPage));
		Routing.RegisterRoute(nameof(FindBusPage), typeof(FindBusPage));
		Routing.RegisterRoute(nameof(RouteDetailsPage), typeof(RouteDetailsPage));
        Routing.RegisterRoute(nameof(UserManagementPage), typeof(UserManagementPage));
        Routing.RegisterRoute(nameof(FleetManagementPage), typeof(FleetManagementPage));

        InitializeComponent();

    }
}
