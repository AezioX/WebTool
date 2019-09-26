using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebTool.Models.DomainDatabase;

namespace WebTool.Services.DomainDatabase
{
    public class DomainDatabaseService : IDomainDatabaseService
    {
        private HttpClient _httpClient = new HttpClient();

        private const string baseURL = "https://api.domainsdb.info/search?query=";

        public async Task<ObservableCollection<DomainsData>> CheckDomainsDatabase(string data)
        {
            var output = new ObservableCollection<DomainsData>();

            var jsonString = await _httpClient.GetStringAsync($"{baseURL}{data}");

            var domains = JsonConvert.DeserializeObject<JsonDomainsData>(jsonString);

            foreach (var domain in domains.Domains)
            {
                output.Add(new DomainsData
                {
                    Domain = domain.DomainDomain,
                    Create_date = domain.CreateDate,
                    Expiry_date = domain.ExpiryDate,
                    Update_date = domain.UpdateDate,
                    IsDead = domain.IsDead,
                    NameServers = domain.Ns
                });
            }

            return output;
        }
    }
}