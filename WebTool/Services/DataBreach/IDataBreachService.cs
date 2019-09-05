using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.DataBreach;

namespace WebTool.Services.DataBreach
{
    public interface IDataBreachService
    {
        Task<ObservableCollection<BreachResults>> CheckAccountAsync(string account);
    }
}