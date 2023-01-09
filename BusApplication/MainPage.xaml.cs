using BusApplication.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BusApplication;

public partial class MainPage : ContentPage
{
	
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

}

