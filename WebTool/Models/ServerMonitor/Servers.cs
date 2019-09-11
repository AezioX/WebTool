using System.Collections.ObjectModel;

namespace WebTool.Models.ServerMonitor
{
    public class Servers
    {
        private Servers()
        {
        }

        private static Servers _servers = new Servers();

        public static Servers getInstance()
        {
            return _servers;
        }

        public ObservableCollection<Server> MonitoredServers { get; set; } = new ObservableCollection<Server>();
    }
}
