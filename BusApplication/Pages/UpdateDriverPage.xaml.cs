using BusApplication.ViewModel;
namespace Pages;

public partial class UpdateDriverPage : ContentPage
{
    public UpdateDriverPage(DriverManagementViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}