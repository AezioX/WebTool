using System;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Services.ServerMonitor;
using WebTool.Models.ServerMonitor;
using System.Reactive.Linq;
using Akavache;

namespace WebTool.ViewModels
{
    public class ServerListAddViewModel : BaseViewModel
    {
        private IServerChecker _serverChecker;

        public ICommand AddCommand => new Command(Add);

        public ServerListAddViewModel(IServerChecker serverChecker)
        {
            _serverChecker = serverChecker;
        }

        private async void Add()
        {
            IsBusy = true;

            var inputDomain = HostName ?? "";
            var preDomain = inputDomain.ToLower();
            var domain = "https://" + preDomain;

            var isDomainValid = await _serverChecker.CheckIfDomainIsValid(domain);

            if(isDomainValid == true)
            {
                var newServersList = await BlobCache.UserAccount.GetObject<Servers>("Servers");

                newServersList.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = Name,
                    HostName = domain
                });

                await BlobCache.UserAccount.InsertObject("Servers", newServersList);

                IsBusy = false;

                //Clear screen
                Name = "";
                HostName = "";

                Shell.Current.SendBackButtonPressed();

                var viewModel = AppContainer.Resolve<ServerMonitorViewModel>();
                viewModel.Refresh();
            }
            else
            {
                IsBusy = false;

                await Application.Current.MainPage.DisplayAlert("Error", $"Use a valid domain and check network connection.", "OK");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;

            set => SetProperty(ref _name, value);
        }

        private string _hostName;
        public string HostName
        {
            get => _hostName;

            set => SetProperty(ref _hostName, value);
        }
    }
}
