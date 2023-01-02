using BusApplication.ViewModel;

namespace BusApplication;

public partial class DriverManagementPage : ContentPage
{
	public DriverManagementPage(DriverManagementViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		
    }
}