using BusApplication.ViewModel;
namespace Pages;

public partial class ViewDriverPage : ContentPage
{
    public ViewDriverPage(DriverManagementViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}