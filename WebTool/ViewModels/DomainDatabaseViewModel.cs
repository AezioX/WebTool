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

        public ICommand ShowInfoCommand => new Command(ShowInfo);

        public DomainDatabaseViewModel(IDomainDatabaseService domainDatabaseService)
        {
            _domainDatabaseService = domainDatabaseService;
        }

        private async void Search()
        {
            IsButtonEnabled = false;

            DomainSearchResults = new ObservableCollection<DomainsData>();

            IsBusy = true;

            try
            {
                DomainSearchResults = await _domainDatabaseService.CheckDomainsDatabase(Domain);

                //API used never returns more than 50 results so this informs the user in case the limit is reached.
                if(DomainSearchResults.Count == 50)
                {
                    DomainSearchResults.Add(new DomainsData { Domain = "" });
                    DomainSearchResults.Add(new DomainsData { Domain = "Limited to 50 results." });
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Unable to access domain database. Check network connection.", "OK");
            }

            IsBusy = false;

            IsButtonEnabled = true;
        }

        private async void ShowInfo()
        {
            await Shell.Current.GoToAsync("DomainDatabaseInfoPage");
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

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get => _isButtonEnabled;

            set => SetProperty(ref _isButtonEnabled, value);
        }
    }
}