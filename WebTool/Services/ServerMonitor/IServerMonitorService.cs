using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public interface IServerMonitorService
    {
        void AddServer(Server server);
        Task<ObservableCollection<Server>> GetUpdatedServersData();
    }
}