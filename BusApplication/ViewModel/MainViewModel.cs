using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel() {
            Items = new ObservableCollection<string>();
            ShowLoginForm = true;
            ShowManagement = false;
            LoginFormUserId = 1;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        int loginFormUserId;

        [ObservableProperty]
        bool showLoginForm;

        [ObservableProperty]
        bool showManagement;


        [RelayCommand]
        async Task NavigateToDriverManagement()
        {
            await Shell.Current.GoToAsync(nameof(DriverManagementPage));
        }
        [RelayCommand]
        async Task NavigateToFindABus()
        {
            await Shell.Current.GoToAsync(nameof(FindBusPage));
        }
        [RelayCommand]
        async Task NavigateToUserManagement()
        {
            await Shell.Current.GoToAsync(nameof(Pages.UserManagementPage));
        }
        [RelayCommand]
        async Task NavigateToFleetManagement()
        {
            await Shell.Current.GoToAsync(nameof(Pages.FleetManagementPage));
        }
        [RelayCommand]
        void Login()
        {
            ShowLoginForm = false;
            Debug.WriteLine(LoginFormUserId);
            App.LoggedInUserId = LoginFormUserId;

            UserType loggedInUserType = App.UserRepo.GetUserTypeFromId(LoginFormUserId);
            if(loggedInUserType == UserType.UserManager || loggedInUserType == UserType.UserManager || loggedInUserType == UserType.Admin)
            {
                ShowManagement = true;
            }
            else
            {
                ShowManagement = false;
            }
        }
    }
}
