using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using WebTool.Models.ServerMonitor;
using System.Collections.Generic;
using WebTool.Views;
using Akavache;

namespace WebTool
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApp();

            MainPage = new AppShell();

            LoadSavedTheme();

            RegisterShellRoutes();

            //Initialize Akavache
            Akavache.Registrations.Start("WebTool");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeApp()
        {
            CreateDefaultServerListIfEmpty();

            AppContainer.RegisterDependencies();
        }

        private void RegisterShellRoutes()
        {
            Routing.RegisterRoute("ServerListAddPage", typeof(ServerListAddPage));
        }

        private void LoadSavedTheme()
        {
            var getSavedTheme = Preferences.Get("CurrentTheme", defaultValue: "noTheme");

            switch (getSavedTheme)
            {
                case "Default Theme":
                    ChangeThemeToDefaultTheme();
                    break;
                case "AezioX's Choice":
                    ChangeThemeToAezioxChoice();
                    break;
                default:
                    ChangeThemeToDefaultTheme();
                    break;
            }
        }

        public static void ChangeThemeToAezioxChoice()
        {
            App.Current.Resources["MainColor"] = "#ff0000";
            App.Current.Resources["FlyoutHeaderImage"] = "nebulared.jpg";
            App.Current.Resources["TigerIcon"] = "tigerred.png";
            App.Current.Resources["HorseIcon"] = "horsered.png";
            App.Current.Resources["OxIcon"] = "oxred.png";
            App.Current.Resources["DogIcon"] = "dogred.png";
            App.Current.Resources["SnakeIcon"] = "snakered.png";
            App.Current.Resources["SettingsIcon"] = "settingsred.png";
            App.Current.Resources["MenuVerticalIcon"] = "menuverticalred.png";
            App.Current.Resources["HomeIcon"] = "homered.png";
            App.Current.Resources["PlusIcon"] = "plusred.png";
            App.Current.Resources["RefreshIcon"] = "refreshred.png";

            Preferences.Set("CurrentTheme", "AezioX's Choice");
        }

        public static void ChangeThemeToDefaultTheme()
        {
            App.Current.Resources["MainColor"] = "#0dff00";
            App.Current.Resources["FlyoutHeaderImage"] = "nebulagreen.jpg";
            App.Current.Resources["TigerIcon"] = "tigergreen.png";
            App.Current.Resources["HorseIcon"] = "horsegreen.png";
            App.Current.Resources["OxIcon"] = "oxgreen.png";
            App.Current.Resources["DogIcon"] = "doggreen.png";
            App.Current.Resources["SnakeIcon"] = "snakegreen.png";
            App.Current.Resources["SettingsIcon"] = "settingsgreen.png";
            App.Current.Resources["MenuVerticalIcon"] = "menuverticalgreen.png";
            App.Current.Resources["HomeIcon"] = "homegreen.png";
            App.Current.Resources["PlusIcon"] = "plusgreen.png";
            App.Current.Resources["RefreshIcon"] = "refreshgreen.png";

            Preferences.Set("CurrentTheme", "Default Theme");
        }

        private void CreateDefaultServerListIfEmpty()
        {
            try
            {
                BlobCache.UserAccount.GetObject<Servers>("Servers");
            }
            catch (Exception)
            {
                var servers = new Servers();

                servers.MonitoredServers.Add(new Server
                {
                    Name = "Google",
                    Status = "",
                    HostName = "https://google.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    Name = "Microsoft",
                    Status = "",
                    HostName = "https://microsoft.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    Name = "Twitter",
                    Status = "",
                    HostName = "https://twitter.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });


                servers.MonitoredServers.Add(new Server
                {
                    Name = "Amazon",
                    Status = "",
                    HostName = "https://amazon.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    Name = "YouTube",
                    Status = "",
                    HostName = "https://youtube.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    Name = "Apple",
                    Status = "",
                    HostName = "https://apple.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                servers.MonitoredServers.Add(new Server
                {
                    Name = "Reddit",
                    Status = "",
                    HostName = "https://reddit.com",
                    Logs = new List<string> { $"Added to list: {DateTime.Now}" }
                });

                BlobCache.UserAccount.InsertObject("Servers", servers);
            }
        }
    }
}