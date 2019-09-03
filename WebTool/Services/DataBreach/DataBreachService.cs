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

        private const string _baseURL = "https://haveibeenpwned.com/api/v3/breachedaccount/";

        private string _hibpApiKey = new Key().APIKEY;

        public DataBreachService()
        {
        }

        public async Task<ObservableCollection<BreachResults>> CheckAccountAsync(string account)
        {
            var output = new ObservableCollection<BreachResults>();



            return output;
        }
    }
}
