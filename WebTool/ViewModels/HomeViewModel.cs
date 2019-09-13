using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand GoToServerMonitorCommand =>
            new Command(async() => await Shell.Current.GoToAsync("//ServerMonitor"));

        public ICommand GoToDomainDatabaseCommand =>
            new Command(async () => await Shell.Current.GoToAsync("//DomainDatabase"));

        public ICommand GoToDataBreachCheckerCommand =>
            new Command(async () => await Shell.Current.GoToAsync("//DataBreachChecker"));

        public ICommand GoToDeviceInfoCommand =>
            new Command(async () => await Shell.Current.GoToAsync("//DeviceInfo"));

        public ICommand GoToSettingsCommand =>
            new Command(async () => await Shell.Current.GoToAsync("//Settings"));
    }
}
