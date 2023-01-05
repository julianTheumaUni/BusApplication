using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BusApplication.ViewModel
{
    public partial class FindBusViewModel : ObservableObject
    {
        [ObservableProperty]
        List<int> displayedRoutes = new List<int> { 1,2,3,4,5,6 };

        [RelayCommand]
        void Test()
        {
            Debug.WriteLine("DisplayedRoutes Count = " + displayedRoutes.Count);
            Debug.WriteLine("DisplayedRoutes Count = " + displayedRoutes.Count);
            Debug.WriteLine("DisplayedRoutes Count = " + displayedRoutes.Count);
        }

        [RelayCommand]
        async Task NavigateToRouteDetailsPage()
        {
            await Shell.Current.GoToAsync(nameof(RouteDetailsPage));
        }

        [RelayCommand]
        void TryAlert()
        {
            Application.Current.MainPage.DisplayAlert("Are you sure you want to request Bus 888 to stop?", "The bus will stop at Bus Stop 999?", "Cancel", "Confirm");
        }
    }
}
