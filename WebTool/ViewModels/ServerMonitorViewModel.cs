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

        public ServerMonitorViewModel(IServerMonitorService serverMonitorService)
        {
            _serverMonitorService = serverMonitorService;
        }

        private async void Refresh()
        {
            IsBusy = true;

            try
            {
                ServersData = await _serverMonitorService.GetUpdatedServersData();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }

            LastUpdated = "Last updated: Aug 10, 15:15";

            IsBusy = false;
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
