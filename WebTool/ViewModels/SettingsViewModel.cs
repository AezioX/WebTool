using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand ChangeToAezioXThemeCommand => new Command(ChangeToAezioXTheme);

        public ICommand ChangeToDefaultThemeCommand => new Command(ChangeToDefaultTheme);

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
    }
}