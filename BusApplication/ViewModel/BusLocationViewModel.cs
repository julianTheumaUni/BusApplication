using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.ViewModel
{
    public partial class BusLocationViewModel : ObservableObject
    {
        [RelayCommand]
        async void RequestPayment()
        {
            bool hasPaid = await Application.Current.MainPage.DisplayAlert("Please pay your bus fare: $5.00", "Your Balance: $21.50", "Confirm", "Cancel");
            if (hasPaid)
            {
                //process payment
            }
        }
    }
}
