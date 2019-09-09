using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServerChecker : IServerChecker
    {
        private HttpClient _httpClient;

        public ServerChecker()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Server>> Check(ObservableCollection<Server> servers)
        {
            var output = new ObservableCollection<Server>();

            await Task.Run(() =>
            {
                Parallel.ForEach(servers, async (server) =>
                {
                    try
                    {
                        using (HttpResponseMessage response = await _httpClient.GetAsync(server.DisplayHost))
                        {
                            string serverStatus = "";
                            serverStatus = Convert.ToString(response.StatusCode);

                            output.Add(new Server
                            {
                                Name = $"{server.Name}",
                                IP = $"{server.IP}",
                                HostName = $"{server.HostName}",
                                DisplayHost = $"{server.DisplayHost}",
                                Status = $"{serverStatus}"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        output.Add(new Server
                        {
                            Name = $"{server.Name}",
                            IP = $"{server.IP}",
                            HostName = $"{server.HostName}",
                            DisplayHost = $"{ex.Message}",
                            Status = $""
                        });
                    }
                });
            });

            return output;
        }
    }
}
