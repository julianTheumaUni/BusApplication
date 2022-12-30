using BusApplication.Repositories;

namespace BusApplication;

public partial class App : Application
{
	public static DriverRepository DriverRepo { get; private set; }
	public App(DriverRepository driverRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
		DriverRepo= driverRepository;

	}
}
