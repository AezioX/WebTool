using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using WebTool.Services.DeviceInfo;

namespace WebTool.ViewModels
{
    public class DeviceInfoViewModel : BaseViewModel
    {
        private IDeviceInfoService _deviceInfoService;

        public ICommand GetCommand => new Command(Get);

        public DeviceInfoViewModel(IDeviceInfoService deviceInfoService)
        {
            _deviceInfoService = deviceInfoService;
        }

        private async void Get()
        {
            IsBusy = true;

            try
            {
                IP = await _deviceInfoService.GetCurrentIPAsync();
            }
            catch (Exception)
            {
                IP = "Error.";
            }

            DeviceName = $"Device Name: {DeviceInfo.Name}";
            DeviceModel = $"Device Model: {DeviceInfo.Model}";
            Manufacturer = $"Manufacturer: {DeviceInfo.Manufacturer}";
            Version = $"OS Version: {DeviceInfo.VersionString}";
            Platform = $"Platform: {DeviceInfo.Platform.ToString()}";
            DeviceType = $"Device Type: {DeviceInfo.DeviceType.ToString()}";

            IsBusy = false;
        }


        private string _iP;
        public string IP
        {
            get => _iP;

            set => SetProperty(ref _iP, value);
        }

        private string _deviceName;
        public string DeviceName
        {
            get => _deviceName;

            set => SetProperty(ref _deviceName, value);
        }

        private string _deviceModel;
        public string DeviceModel
        {
            get => _deviceModel;

            set => SetProperty(ref _deviceModel, value);
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;

            set => SetProperty(ref _manufacturer, value);
        }

        private string _version;
        public string Version
        {
            get => _version;

            set => SetProperty(ref _version, value);
        }

        private string _platform;
        public string Platform
        {
            get => _platform;

            set => SetProperty(ref _platform, value);
        }

        private string _deviceType;

        public string DeviceType
        {
            get => _deviceType;

            set => SetProperty(ref _deviceType, value);
        }
    }
}
