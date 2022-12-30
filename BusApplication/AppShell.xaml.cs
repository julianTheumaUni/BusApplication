namespace BusApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DriverManagementPage), typeof(DriverManagementPage));
	}
}
