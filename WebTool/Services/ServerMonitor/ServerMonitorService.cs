using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Akavache;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerMonitorService : IServerMonitorService
    {
        private IServerChecker _serverChecker;

        //BlobCache.UserAccount.GetObject<Servers>("Servers");
        private Servers _servers = new Servers();

        public ServerMonitorService(IServerChecker serverChecker)
        {
            _serverChecker = serverChecker;
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
