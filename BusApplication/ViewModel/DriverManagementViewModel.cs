using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class DriverManagementViewModel : ObservableObject
    {
        [RelayCommand]
        void Add()
        {
            Debug.WriteLine("Adding from View Model");
            App.DriverRepo.AddDriver(new DateTime(DateTime.Now.Year), "24, Triq il-Kbira, Mosta", "21212121", "John");
            App.DriverRepo.GetAllDrivers().ForEach(driver => { Debug.WriteLine(driver.Name); });
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
            drivers.ForEach(driver => { Debug.WriteLine(driver.Name); });
        }
    }
}
