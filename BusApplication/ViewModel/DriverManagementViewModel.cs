using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class DriverManagementViewModel : ObservableObject
    {

        public ObservableCollection<DriverCollectionView> DriversCollectionViewItems { get; set; }


        [RelayCommand]
        void Add()
        {
            Debug.WriteLine("Adding from View Model");
            App.UserRepo.AddUser(UserType.BusDriver);
            //get this added user's id and place below. TODO
            App.DriverRepo.AddDriver(DateTime.Now, "22, Triq il-Kbira, Mosta", "99999999", 3);
        }

        /*
         *void requestStop()
         *{
         *  App.DriverRepo.SetStopStatus(true);
         *  Driver's Frontend change colour
         *}
         *
         *
         */

        [RelayCommand]
        void GetAllDrivers()
        {
            List<Driver> drivers = App.DriverRepo.GetAllDrivers();
            //drivers.ForEach(driver => { Debug.WriteLine(driver.Name); });
        }

        public List<Driver> GetDrivers()
        {
            return App.DriverRepo.GetAllDrivers();
        }

        public void SetDriverCollectionView()
        {
            List<Driver> drivers = GetDrivers();
            List<DriverCollectionView> driverCollection = new List<DriverCollectionView>();
            drivers.ForEach(driver =>
            {
                //string driverName = driver.Name;
                //int driverBus = driver.BusNumber;
                //DriversCollectionViewItems.Add(new DriverCollectionView { Name = driverName, BusNumber = driverBus });
            });
        }

        [RelayCommand]
        async Task NavigateToViewDriverPage()
        {
            await Shell.Current.GoToAsync(nameof(ViewDriverPage));
        }

        [RelayCommand]
        async Task NavigateToAddDriverPage()
        {
            await Shell.Current.GoToAsync(nameof(AddDriverPage));
        }

        [RelayCommand]
        async Task NavigateToUpdateDriverPage()
        {
            await Shell.Current.GoToAsync(nameof(UpdateDriverPage));

        }
        [RelayCommand]
        async Task NavigateToDeleteDriverPage()
        {
            await Shell.Current.GoToAsync(nameof(DeleteDriverPage));
        }
    }
    //[RelayCommand]
    //void Update()
    // {

    //   }
    //  [RelayCommand]
    // void Delete()
    // {

    //   }

    public class DriverCollectionView
    {
        public string Name { get; set; }
        public int BusNumber { get; set; }
    }
}
