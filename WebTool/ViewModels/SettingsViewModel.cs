using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows.Input;
using Akavache;
using WebTool.Models.ServerMonitor;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand ChangeToAezioXThemeCommand => new Command(ChangeToAezioXTheme);

        public ICommand ChangeToDefaultThemeCommand => new Command(ChangeToDefaultTheme);

        public ICommand RestoreServerListCommand => new Command(RestoreServerList);

        public ICommand DeleteServerListCommand => new Command(DeleteServerList);

        public SettingsViewModel()
        {
        }

        private async void ChangeToAezioXTheme()
        {
            //If it's the red theme already do nothing.
            if ((string)App.Current.Resources["MainColor"] == "#ff0000")
                return;

            App.ChangeThemeToAezioxChoice();

            await Shell.Current.GoToAsync("//Home");
        }

        private async void ChangeToDefaultTheme()
        {
            //If it's the green theme already do nothing.
            if ((string)App.Current.Resources["MainColor"] == "#0dff00")
                return;

            App.ChangeThemeToDefaultTheme();

            await Shell.Current.GoToAsync("//Home");
        }

        private async void RestoreServerList()
        {
            try
            {
                var servers = new Servers();

                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "Google",
                    Status = "",
                    HostName = "https://google.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "Twitter",
                    Status = "",
                    HostName = "https://twitter.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });


                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "Amazon",
                    Status = "",
                    HostName = "https://amazon.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "YouTube",
                    Status = "",
                    HostName = "https://youtube.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "Apple",
                    Status = "",
                    HostName = "https://apple.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "Netflix",
                    Status = "",
                    HostName = "https://netflix.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt")}" }
                });

                await BlobCache.UserAccount.InsertObject("Servers", servers);

                await Application.Current.MainPage.DisplayAlert("", "Default server list restored.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }

        private async void DeleteServerList()
        {
            try
            {
                var servers = new Servers();

                await BlobCache.UserAccount.InsertObject("Servers", servers);

                await Application.Current.MainPage.DisplayAlert("", "Server list deleted.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }
    }
}