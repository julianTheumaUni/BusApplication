using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BusApplication.ViewModel;

public partial class UserManagementViewModel : ObservableObject
{
    [RelayCommand]
    public void AddUser()
    {
        App.UserRepo.AddUser(Models.UserType.Admin);
    }
}      
    public class types
    {
        enum userTypes { Child, Student, Adult, Concession }

        
    }



