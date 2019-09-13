using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand GoToServerMonitorCommand => new Command(GoToServerMonitor);

        public HomeViewModel()
        {
            
        }

        private async void GoToServerMonitor()
        {
            await Shell.Current.GoToAsync("//ServerMonitor");
        }
    }
}
