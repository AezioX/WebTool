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
            App.ChangeThemeToAezioxChoice();

            await Shell.Current.GoToAsync("//Home");
        }

        private async void ChangeToDefaultTheme()
        {
            App.ChangeThemeToDefaultTheme();

            await Shell.Current.GoToAsync("//Home");
        }
    }
}