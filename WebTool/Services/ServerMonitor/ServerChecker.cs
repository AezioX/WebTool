using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading;
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
                        //Prevents seemingly random Foundation.MonoTouch exception
                        Thread.Sleep(100);

                        using (HttpResponseMessage response = await _httpClient.GetAsync(server.HostName))
                        {
                            string serverStatus = "";
                            serverStatus = Convert.ToString(response.StatusCode);

                            output.Add(new Server
                            {
                                ID = $"{server.ID}",
                                Name = $"{server.Name}",
                                HostName = $"{server.HostName}",
                                Status = $"{serverStatus}"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        output.Add(new Server
                        {
                            ID = $"{server.ID}",
                            Name = $"{server.Name}",
                            HostName = $"{ex.Message}",
                            Status = $""
                        });
                    }
                });
            });

            return output;
        }

        public async Task<bool> CheckIfDomainIsValid(string domain)
        {
            var output = false;

            await Task.Run(async () =>
            {
                try
                {
                    using (HttpResponseMessage response = await _httpClient.GetAsync(domain))
                    {
                        string serverStatus = "";
                        serverStatus = Convert.ToString(response.StatusCode);

                        if (serverStatus == "OK")
                            output = true;
                    }
                }
                catch (Exception)
                {
                    output = false;
                }
            });

            return output;
        }
    }
}
