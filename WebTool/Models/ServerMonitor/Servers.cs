using System.Collections.ObjectModel;

namespace WebTool.Models.ServerMonitor
{
    public static class Servers
    {
        public static ObservableCollection<Server> MonitoredServers { get; set; } = new ObservableCollection<Server>();
    }
}
