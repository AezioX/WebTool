using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerMonitorService : IServerMonitorService
    {
        private ServerChecker _serverChecker;

        public ServerMonitorService()
        {
            _serverChecker = new ServerChecker();

            #region Add Servers Region
            _servers.Add(new Server
            {
                Name = "AezioX",
                IP = "198.58.102.44",
                Status = "303 (OK)",
                HostName = "https://aeziox.com",
                DisplayHost = "198.58.102.44",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });

            _servers.Add(new Server
            {
                Name = "Sennheiser",
                IP = "198.58.102.44",
                Status = "200 (OK)",
                HostName = "https://microsoft.com",
                DisplayHost = "https://microsoft.com",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });

            _servers.Add(new Server
            {
                Name = "Apple",
                IP = "198.58.102.44",
                Status = "200 (OK)",
                HostName = "https://apple.com",
                DisplayHost = "https://apple.com",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });

            _servers.Add(new Server
            {
                Name = "Twitter",
                IP = "198.58.102.44",
                Status = "200 (OK)",
                HostName = "https://1.com",
                DisplayHost = "https://twitter.com",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });

            _servers.Add(new Server
            {
                Name = "Yahoo",
                IP = "198.58.102.44",
                Status = "200 (OK)",
                HostName = "https://2.com",
                DisplayHost = "https://2131htr12312dfsd.com",
                Logs = new List<string> { "200 at Aug 10", "200 at Aug 11" }
            });
            #endregion
        }

        private ObservableCollection<Server> _servers = new ObservableCollection<Server>();

        public void AddServer(Server server)
        {
            _servers.Add(server);
        }

        public async Task<ObservableCollection<Server>> GetUpdatedServersData()
        {
            var output = new ObservableCollection<Server>();
            var serverChecker = _serverChecker;

            try
            {
                output = await serverChecker.Check(_servers);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }
    }
}
