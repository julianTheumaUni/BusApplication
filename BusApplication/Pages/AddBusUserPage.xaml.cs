using BusApplication.ViewModel;

namespace Pages;

public partial class AddBusUserPage : ContentPage
{
	public AddBusUserPage(UserManagementViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
