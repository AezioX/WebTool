using System;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Services.ServerMonitor;
using WebTool.Models.ServerMonitor;

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
            var inputDomain = HostName;
            var domain = inputDomain.ToLower();

            var isDomainValid = await _serverChecker.CheckIfDomainIsValid(domain);

            if(isDomainValid == true)
            {
                var newServersList = (Servers)App.Current.Resources["ServerList"];

                newServersList.MonitoredServers.Add(new Server
                {
                    Name = Name,
                    HostName = domain
                });

                App.Current.Resources["ServerList"] = newServersList;

                //Clear screen
                Name = "";
                HostName = "";

                Shell.Current.SendBackButtonPressed();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Use a valid domain.", "OK");
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
