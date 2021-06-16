using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExtendedShellTabBarSample.ViewModels
{
    public class AppShellViewModel
    {
        public ICommand ClickCommand { get; set; }

        public AppShellViewModel()
        {

            ClickCommand = new Command(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Click !", "You click the centered button inside the TabBar", "OK");
            });
        }
    }
}
