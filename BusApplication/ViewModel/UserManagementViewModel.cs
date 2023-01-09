using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Pages;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BusApplication.ViewModel;

public partial class UserManagementViewModel : ObservableObject
{
    public ObservableCollection<DriverCollectionView> DriversCollectionViewItems { get; set; }

    [ObservableProperty]
    public string inputSelectedUserType;

    [ObservableProperty]
    public string inputSelectedBusUserType;
    [ObservableProperty]
    public bool busUserIsSelected;

    public UserManagementViewModel() {
        InputSelectedUserType = "";
        InputSelectedBusUserType = "";
        BusUserIsSelected= false;
    }

    public int AddUser(UserType userType)
    {
        return App.UserRepo.AddUser(userType);
    }


    [RelayCommand]
    void AddBusUser()
    {
        UserType ut = UserType.BusUser;
        if(InputSelectedUserType == "Driver")
        {
            BusUserIsSelected = false;
            Shell.Current.GoToAsync(nameof(Pages.AddDriverPage));
            return;
        }
        if(InputSelectedUserType == "Admin")
        {
            ut = UserType.Admin;
            BusUserIsSelected = false;
        }
        else if(InputSelectedUserType == "Bus User")
        {
            ut = UserType.BusUser;
            BusUserIsSelected = true;
        }
        else if(InputSelectedUserType == "Driver Manager")
        {
            ut = UserType.DriverManager;
            BusUserIsSelected = false;
        }
        else if(InputSelectedUserType == "User Manager")
        {
            ut = UserType.UserManager;
            BusUserIsSelected = false;
        }

        int createdUserId = AddUser(ut);
        Types userType = Types.Child;
        Debug.WriteLine("CRREATED USER ID.........." + createdUserId);
        if(InputSelectedBusUserType == "Student")
        {
            userType = Types.Student;
        }
        else if(InputSelectedBusUserType == "Adult")
        {
            userType = Types.Adult;
        }
        else if (InputSelectedBusUserType == "Child")
        {
            userType = Types.Child;
        }
        else if (InputSelectedBusUserType == "Concession")
        {
            userType = Types.Concession;
        }

        Debug.WriteLine("User Type: " + userType);
        App.BusUserRepo.AddBusUser(userType, createdUserId) ;
    }

    [RelayCommand]
    async Task AddBusUserPage()
    {
        await Shell.Current.GoToAsync(nameof(Pages.AddBusUserPage));
    }

    [RelayCommand]
    void GetSelected()
    {
        Debug.WriteLine(InputSelectedUserType);
        Debug.WriteLine(BusUserIsSelected.ToString());
    }

    [RelayCommand]
    void GetAllUsers()
    {
        List<User> users = App.UserRepo.GetAllUsers();
        users.ForEach(user => { Debug.WriteLine($"ID: {user.UserId} Type: {user.UserType}"); });
        Debug.WriteLine(InputSelectedUserType);
    }
}

