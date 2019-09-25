using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerMonitorService : IServerMonitorService
    {
        private IServerChecker _serverChecker;

        private IServersService _serversService;

        private Servers _servers = new Servers();

        public ServerMonitorService(IServerChecker serverChecker)
        {
            _serverChecker = serverChecker;
        }

        public async Task<ObservableCollection<Server>> GetUpdatedServersData()
        {
            var output = new ObservableCollection<Server>();

            //Prevents seemingly random Foundation.MonoTouch exception
            Thread.Sleep(120);

            _servers = await GetStoredServerListAsync();

            var preprocessed = new ObservableCollection<Server>();
            foreach(var server in _servers.MonitoredServers)
            {
                //Prevents seemingly random Foundation.MonoTouch exception
                Thread.Sleep(120);

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