using BusApplication.ViewModel;
namespace Pages;

public partial class DeleteDriverPage : ContentPage
{
    public DeleteDriverPage(DriverManagementViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}