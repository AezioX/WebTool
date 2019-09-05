using System.Threading.Tasks;

namespace WebTool.Services.DeviceInfo
{
    public interface IDeviceInfoService
    {
        Task<string> GetCurrentIPAsync();
    }
}