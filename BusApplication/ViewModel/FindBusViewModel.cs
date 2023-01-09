using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class FindBusViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Bus> busList;

        public FindBusViewModel()
        {
            busList = App.BusRepo.GetAllBuses();
        }

        [ObservableProperty]
        List<int> displayedRoutes = new List<int> { 1, 2, 3, 4, 5, 6 };

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
        async void TryAlert()
        {
            bool isConfirmed = await Application.Current.MainPage.DisplayAlert("Are you sure you want to request Bus 888 to stop?", "The bus will stop at Bus Stop 999?", "Confirm", "Cancel");
            Debug.WriteLine("IS CONFIIIIIIIIIIIIIIIIIIIIRMED ", isConfirmed.ToString());
            if (isConfirmed)
            {
                //bool hasPaid = await Application.Current.MainPage.DisplayAlert("Please pay your bus fare: $5.00", "Your Balance: $21.50", "Confirm", "Cancel");
                await Shell.Current.GoToAsync(nameof(BusLocationPage));
            }
        }

        public ObservableCollection<BusCollectionView> BusCollectionViewItems { get; set; }

	    [RelayCommand]
        void AddBus()
        {
            Debug.WriteLine("Adding from View Model");
            App.RouteRepo.AddRoute("Marsaskala", "Sliema");
            App.BusRepo.AddBus(true, 50, 1);
            App.BusRepo.GetAllBuses().ForEach(bus => { Debug.WriteLine(bus.BusId); });
	    busList = App.BusRepo.GetAllBuses();
        }

	    [RelayCommand]
        void GetAllBuses()
        {
            List<Bus> buses = App.BusRepo.GetAllBuses();
            buses.ForEach(bus => { Debug.WriteLine(bus.BusId); });
        }

	public List<Bus> GetBuses()
        {
            return App.BusRepo.GetAllBuses();
        }

	public void SetBusCollectionView()
        {
            List<Bus> buses = GetBuses();
            List<BusCollectionView> busCollection = new List<BusCollectionView>();
            buses.ForEach(bus =>
            {
                int busNumber = bus.BusId;
                BusCollectionViewItems.Add(new BusCollectionView { busId = busNumber});
            });
        }
	
    }

    public class BusCollectionView
    {
        public int busId { get; set; }
    }
}
