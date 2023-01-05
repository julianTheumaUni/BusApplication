using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BusApplication.ViewModel;

public partial class UserManagementViewModel : ObservableObject
{
    public class types
    {
        enum userTypes { Child, Student, Adult, Concession }
    }
}



