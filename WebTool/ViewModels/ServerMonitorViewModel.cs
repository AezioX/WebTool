using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;
using WebTool.Services.ServerMonitor;

namespace WebTool.ViewModels
{
    public class ServerMonitorViewModel : BaseViewModel
    {
        private IServerMonitorService _serverMonitorService;

        public ICommand RefreshCommand => new Command(Refresh);

        public ICommand GoToAddPageCommand => new Command(GoToAddPage);

        public ServerMonitorViewModel(IServerMonitorService serverMonitorService)
        {
            _serverMonitorService = serverMonitorService;
        }

        private async void Refresh()
        {
            IsBusy = true;

            ServersData = new ObservableCollection<Server>();

            try
            {
                ServersData = await _serverMonitorService.GetUpdatedServersData();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
                IsBusy = false;
            }

            LastUpdated = "Last updated: Aug 10, 15:15";

            IsBusy = false;
        }

        private async void GoToAddPage()
        {
            await Shell.Current.GoToAsync("ServerListAddPage");
        }

        private ObservableCollection<Server> _serversData;
        public ObservableCollection<Server> ServersData
        {
            get => _serversData;

            set => SetProperty(ref _serversData, value);
        }

        private string _lastUpdated;
        public string LastUpdated
        {
            get => _lastUpdated;

            set => SetProperty(ref _lastUpdated, value);
        }
    }
}
