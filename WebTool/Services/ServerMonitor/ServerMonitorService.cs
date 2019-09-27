using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerMonitorService : IServerMonitorService
    {
        private IServerChecker _serverChecker;

        private IServersService _serversService;

        private Servers _servers = new Servers();

        public ServerMonitorService(IServerChecker serverChecker, IServersService serversService)
        {
            _serverChecker = serverChecker;

            _serversService = serversService;
        }

        public async Task<ObservableCollection<Server>> GetUpdatedServersDataAsync()
        {
            var output = new ObservableCollection<Server>();

            //Prevents seemingly random Foundation.MonoTouch exception
            Thread.Sleep(200);

            _servers = await _serversService.GetStoredServerListAsync();

            var preprocessed = new ObservableCollection<Server>();
            foreach(var server in _servers.MonitoredServers)
            {
                //Prevents seemingly random Foundation.MonoTouch exception
                Thread.Sleep(200);

                preprocessed.Add(server);
            }

            try
            {
                output = await _serverChecker.CheckAsync(preprocessed);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }
    }
}