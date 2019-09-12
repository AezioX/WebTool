using System;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Services.ServerMonitor;

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

        private void Add()
        {
            
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
