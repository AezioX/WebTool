using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public class ServersService : IServersService
    {
        public async Task<Servers> GetStoredServerListAsync()
        {
            var output = new Servers();

            output = await BlobCache.UserAccount.GetObject<Servers>("Servers");

            return output;
        }
    }
}
