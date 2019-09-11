using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerMonitorService : IServerMonitorService
    {
        private IServerChecker _serverChecker;

        private Servers _servers = Servers.getInstance();

        public ServerMonitorService(IServerChecker serverChecker)
        {
            _serverChecker = serverChecker;

            _servers.MonitoredServers.Add(new Server
            {
                Name = "AezioX",
                Status = "200 (OK)",
                HostName = "https://aeziox.com",
                DisplayHost = "198.58.102.44",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });

            _servers.MonitoredServers.Add(new Server
            {
                Name = "Twitter",
                Status = "200 (OK)",
                HostName = "https://1.com",
                DisplayHost = "https://twitter.com",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });
        }

        public void AddServer(Server server)
        {
            
        }

        public async Task<ObservableCollection<Server>> GetUpdatedServersData()
        {
            var output = new ObservableCollection<Server>();

            var preprocessed = new ObservableCollection<Server>();
            foreach(var server in _servers.MonitoredServers)
            {
                preprocessed.Add(server);
            }

            try
            {
                output = await _serverChecker.Check(preprocessed);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }
    }
}
