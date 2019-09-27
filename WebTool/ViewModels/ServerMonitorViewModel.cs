using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;
using WebTool.Services.ServerMonitor;
using System.Threading;
using Akavache;
using System.Reactive.Linq;
using System.Threading.Tasks;

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

            if (await CheckIfServerListIsEmpty() == true)
            {
                IsBusy = false;

                LastUpdated = "Server list is empty.";

                return;
            }

            //Prevents seemingly random Foundation.MonoTouch exception
            Thread.Sleep(200);

            try
            {
                ServersData = await _serverMonitorService.GetUpdatedServersDataAsync();

                IsBusy = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
                IsBusy = false;
            }

            LastUpdated = $"Last updated: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}";
        }

        private async Task<bool> CheckIfServerListIsEmpty()
        {
            var serverList = await BlobCache.UserAccount.GetObject<Servers>("Servers");

            if (serverList.MonitoredServers.Count == 0)
                return true;

            return false;
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