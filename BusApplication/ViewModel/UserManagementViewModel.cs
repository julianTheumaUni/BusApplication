using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BusApplication.ViewModel;

public partial class UserManagementViewModel : ObservableObject
{
    
    public void AddUser(UserType _userType)
    {
        App.UserRepo.AddUser(_userType);
    }

    [RelayCommand]
    public void AddBusUser()
    {
        AddUser(Models.UserType.BusUser);
        App.BusUserRepo.AddBusUser(Models.Types.Adult, 2);
    }
}      
    public class types
    {
        enum userTypes { Child, Student, Adult, Concession }

        
    }



