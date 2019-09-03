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

        private void ChangeToAezioXTheme()
        {
            App.ChangeThemeToAezioxChoice();
        }

        private void ChangeToDefaultTheme()
        {
            App.ChangeThemeToDefaultTheme();
        }
    }
}