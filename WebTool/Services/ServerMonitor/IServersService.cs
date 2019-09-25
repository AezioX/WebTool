using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public interface IServersService
    {
        Task<Servers> GetStoredServerListAsync();
    }
}