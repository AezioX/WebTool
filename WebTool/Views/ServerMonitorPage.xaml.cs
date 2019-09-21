using System;
using WebTool.ViewModels;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;
using Akavache;
using System.Reactive.Linq;
using System.Linq;

namespace WebTool.Views
{
    public partial class ServerMonitorPage : ContentPage
    {
        public ServerMonitorPage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<ServerMonitorViewModel>();
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var selectedServer = (Server)mi.CommandParameter;

            var servers = await BlobCache.UserAccount.GetObject<Servers>("Servers");

            servers.MonitoredServers.Remove(servers.MonitoredServers.Where(i => i.ID == selectedServer.ID).Single());

            await BlobCache.UserAccount.InsertObject("Servers", servers);

            listServers.ItemsSource = servers.MonitoredServers;
            
        }
    }
}
