using BusApplication.ViewModel;

namespace BusApplication;

public partial class FindBusPage : ContentPage
{
    public FindBusPage(FindBusViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }
}
