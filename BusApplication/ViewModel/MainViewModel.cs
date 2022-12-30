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
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        

        [RelayCommand]
        async Task NavigateToDriverManagement()
        {
            await Shell.Current.GoToAsync(nameof(DriverManagementPage));
        }
    }
}
