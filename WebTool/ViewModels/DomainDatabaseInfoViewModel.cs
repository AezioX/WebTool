using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class DomainDatabaseInfoViewModel : BaseViewModel
    {
        public ICommand GoToSiteCommand => new Command<string>(OpenBrowser);

        private void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
