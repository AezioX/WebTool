using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;

namespace WebTool.ViewModels
{
    public class ServerListViewModel : BaseViewModel
    {
        public ICommand AddCommand => new Command(Add);

        public ServerListViewModel()
        {
        }

        private void Add()
        {
            
        }

        private ObservableCollection<Server> _allServers;
        public ObservableCollection<Server> AllServers
        {
            get => _allServers;

            set => SetProperty(ref _allServers, value);
        }
    }
}
