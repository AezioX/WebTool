using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebTool.ViewModels
{
    public class DomainDatabaseViewModel : BaseViewModel
    {
        public ICommand SearchCommand => new Command(Search);

        private async void Search()
        {
            try
            {
                DomainSearchResults = await _domainCenter.CheckDomainsDatabase(Domain);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }

        }

        private string _domain;
        public string Domain
        {
            get => _domain;

            set => SetProperty(ref _domain, value);
        }

        private ObservableCollection<DomainsData> _domainSearchResults;
        public ObservableCollection<DomainsData> DomainSearchResults
        {
            get => _domainSearchResults;

            set => SetProperty(ref _domainSearchResults, value);
        }
    }
}
