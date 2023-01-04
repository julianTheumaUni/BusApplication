using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }
    }
}
