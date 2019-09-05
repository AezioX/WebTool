using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebTool.Models.DomainDatabase;

namespace WebTool.Services.DomainDatabase
{
    public interface IDomainDatabaseService
    {
        Task<ObservableCollection<DomainsData>> CheckDomainsDatabase(string data);
    }
}