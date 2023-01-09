using BusApplication.ViewModel;

namespace Pages;

public partial class UserManagementPage : ContentPage
{
    public UserManagementPage(UserManagementViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }
}