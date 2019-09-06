using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebTool
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LoadSavedTheme();

            InitializeApp();

            MainPage = new AppShell();
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
            AppContainer.RegisterDependencies();
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
            App.Current.Resources["FlyoutHeaderImage"] = "Red/Nebula-Red.jpg";
            App.Current.Resources["Tiger"] = "Red/tiger.png";
            Preferences.Set("CurrentTheme", "AezioX's Choice");
        }

        public static void ChangeThemeToDefaultTheme()
        {
            App.Current.Resources["MainColor"] = "#0dff00";
            App.Current.Resources["FlyoutHeaderImage"] = "Green/Nebula-Green.jpg";

            App.Current.Resources["TigerIcon"] = "Green/tiger.png";
            App.Current.Resources["HorseIcon"] = "Green/horse.png";
            App.Current.Resources["OxIcon"] = "Green/ox.png";
            App.Current.Resources["SnakeIcon"] = "Green/snake.png";
            App.Current.Resources["SettingsIcon"] = "Green/settings.png";


            Preferences.Set("CurrentTheme", "Default Theme");
        }
    }
}
