using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using WebTool.Models.DataBreach;

namespace WebTool.Services.DataBreach
{
    public class DataBreachService
    {
        private HttpClient _httpClient = new HttpClient();

        public DataBreachService()
        {
        }

        public async Task<ObservableCollection<BreachResults>> CheckAccountAsync(string account)
        {

        }
    }
}
