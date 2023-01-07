using BusApplication.ViewModel;

namespace Pages;

public partial class FindBusPage : ContentPage
{
	public FindBusPage(FindBusViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
