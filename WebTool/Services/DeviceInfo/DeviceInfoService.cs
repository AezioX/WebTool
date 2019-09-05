using System.Net.Http;
using System.Threading.Tasks;

namespace WebTool.Services.DeviceInfo
{
    public class DeviceInfoService
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<string> GetCurrentIPAsync()
        {
            var output = "";

            var ip = await _httpClient.GetStringAsync("https://api.ipify.org");
            output = $"Public IP address: {ip}";

            return output;
        }
    }
}
