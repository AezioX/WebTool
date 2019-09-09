using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.ServerMonitor;

namespace WebTool.Services.ServerMonitor
{
    public interface IServerChecker
    {
        Task<ObservableCollection<Server>> Check(ObservableCollection<Server> servers);
    }
}