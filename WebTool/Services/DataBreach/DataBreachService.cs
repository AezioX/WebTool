using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebTool.Models.DataBreach;

namespace WebTool.Services.DataBreach
{
    public class DataBreachService : IDataBreachService
    {
        private HttpClient _httpClient = new HttpClient();

        private const string _baseURL = "https://haveibeenpwned.com/api/v3/breachedaccount/";

        private string _hibpApiKey = new Key().APIKEY;

        private string _userAgent = new Key().UserAgent;

        public DataBreachService()
        {
            _httpClient.DefaultRequestHeaders.Add("hibp-api-key", _hibpApiKey);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(_userAgent);
        }

        public async Task<ObservableCollection<BreachResults>> CheckAccountAsync(string account)
        {
            var output = new ObservableCollection<BreachResults>();

            var preQueryString = $"{_baseURL}{account}";
            var finalQueryString = preQueryString + "?truncateResponse=false";

            var jsonString = await _httpClient.GetStringAsync(finalQueryString);

            var results = JsonConvert.DeserializeObject<List<JsonBreachResults>>(jsonString);

            //Fill the output of this method with the results of the JSON deserialization.
            foreach (var result in results)
            {
                //This List will be assigned to "DataClasses" of each BreachResults object.
                var dataClasses = new List<DataType>();
                foreach (var name in result.DataClasses)
                {
                    dataClasses.Add(new DataType { Name = name });
                }


                output.Add(new BreachResults
                {
                    DataClasses = dataClasses,

                    Name = result.Name,
                    Title = result.Title,
                    Domain = result.Domain,
                    BreachDate = result.BreachDate,
                    AddedDate = result.AddedDate,
                    ModifiedDate = result.ModifiedDate,
                    PwnCount = result.PwnCount,
                    Description = result.Description,
                    LogoPath = result.LogoPath,
                    IsVerified = result.IsVerified.ToString(),
                    IsFabricated = result.IsFabricated.ToString(),
                    IsSensitive = result.IsSensitive.ToString(),
                    IsRetired = result.IsRetired.ToString(),
                    IsSpamList = result.IsSpamList.ToString()
                });
            }

            return output;
        }
    }
}
