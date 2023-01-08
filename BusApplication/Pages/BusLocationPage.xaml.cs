using BusApplication.ViewModel;

namespace Pages;

public partial class BusLocationPage : ContentPage
{
    public BusLocationPage(BusLocationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}