using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class AddDriverViewModel : ObservableObject
    {
        public AddDriverViewModel()
        {
            InputDateOfBirth = String.Empty;
            InputAddress = String.Empty;
            InputPhoneNumber = String.Empty;
            SuccessPopUp= false;
            FailPopUp = false;
        }

        [ObservableProperty]
        string inputDateOfBirth;
        [ObservableProperty]
        string inputAddress;
        [ObservableProperty]
        string inputPhoneNumber;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        bool successPopUp = false;
        [ObservableProperty]
        bool failPopUp = false;

        [RelayCommand]
        void Add()
        {
            DateTime dob = ConvertStringToDateTime(InputDateOfBirth);
            int newUserId = App.UserRepo.AddUser(UserType.BusDriver);
            //get this added user's id and place below. TODO
            Debug.WriteLine(newUserId);
            App.DriverRepo.AddDriver(dob, InputAddress, InputPhoneNumber, newUserId);

            if(newUserId >= 0)
            {
                SuccessPopUp = true;
                FailPopUp = false;
            }
            else
            {
                SuccessPopUp = false;
                FailPopUp = true;
            }
            ResetPopUps();
        }

        public DateTime ConvertStringToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private async void ResetPopUps()
        {
            await Task.Delay(3000);
            SuccessPopUp = false;
            FailPopUp = false;
        }

        [RelayCommand]

        void DeleteDriver(int s)
        {
            List<Driver> Items = App.DriverRepo.GetAllDrivers();

            Items.ForEach(item =>
            {
                if (item.UserId == s)
                {
                    App.DriverRepo.DeleteDriver(s);
                    return;
                    
                }
            });
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

}
