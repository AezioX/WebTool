using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.DomainDatabase;
using WebTool.Services.DomainDatabase;

namespace WebTool.ViewModels
{
    public class DomainDatabaseViewModel : BaseViewModel
    {
        private IDomainDatabaseService _domainDatabaseService;

        public ICommand SearchCommand => new Command(Search);

        public DomainDatabaseViewModel(IDomainDatabaseService domainDatabaseService)
        {
            _domainDatabaseService = domainDatabaseService;
        }

        private async void Search()
        {
            try
            {
                DomainSearchResults = await _domainDatabaseService.CheckDomainsDatabase(Domain);
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
