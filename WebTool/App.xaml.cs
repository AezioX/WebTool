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

            InitializeApp();

            MainPage = new AppShell();

            LoadSavedTheme();
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
            App.Current.Resources["FlyoutHeaderImage"] = "nebulared.jpg";
            App.Current.Resources["TigerIcon"] = "tigerred.png";
            App.Current.Resources["HorseIcon"] = "horsered.png";
            App.Current.Resources["OxIcon"] = "oxred.png";
            App.Current.Resources["DogIcon"] = "dogred.png";
            App.Current.Resources["SnakeIcon"] = "snakered.png";
            App.Current.Resources["SettingsIcon"] = "settingsred.png";

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

            Preferences.Set("CurrentTheme", "Default Theme");
        }
    }
}