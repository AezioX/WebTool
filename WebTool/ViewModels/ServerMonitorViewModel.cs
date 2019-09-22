using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;
using WebTool.Services.ServerMonitor;
using System.Threading;

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

        public async void Refresh()
        {
            IsBusy = true;

            ServersData = new ObservableCollection<Server>();

            //Prevents seemingly random Foundation.MonoTouch exception
            Thread.Sleep(100);

            try
            {
                ServersData = await _serverMonitorService.GetUpdatedServersData();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
                IsBusy = false;
            }

            LastUpdated = $"Last updated: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}";
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
