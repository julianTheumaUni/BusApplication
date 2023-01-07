using BusApplication.ViewModel;
namespace Pages;

public partial class AddDriverPage : ContentPage
{
    public AddDriverPage(DriverManagementViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}