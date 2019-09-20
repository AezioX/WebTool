using System.Collections.ObjectModel;

namespace WebTool.Models.ServerMonitor
{
    public class Servers
    {
        public ObservableCollection<Server> MonitoredServers { get; set; } = new ObservableCollection<Server>();
    }
}
