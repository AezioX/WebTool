using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using WebTool.Models.DataBreach;
using WebTool.Services.DataBreach;

namespace WebTool.ViewModels
{
    public class DataBreachViewModel : BaseViewModel
    {
        private IDataBreachService _dataBreachService;

        public ICommand CheckAccountCommand => new Command(CheckAccount);

        public ICommand ShowInfoCommand => new Command(ShowInfo);

        public DataBreachViewModel(IDataBreachService dataBreachService)
        {
            _dataBreachService = dataBreachService;
        }

        private async void CheckAccount()
        {
            Results = new ObservableCollection<BreachResults>();

            IsBusy = true;

            try
            {
                Results = await _dataBreachService.CheckAccountAsync(Account);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }

            IsBusy = false;
        }

        private async void ShowInfo()
        {
            await Shell.Current.GoToAsync("DataBreachInfoPage");
        }

        private ObservableCollection<BreachResults> _results;
        public ObservableCollection<BreachResults> Results
        {
            get => _results;

            set => SetProperty(ref _results, value);
        }

        private string _account;
        public string Account
        {
            get => _account;

            set => SetProperty(ref _account, value);
        }
    }
}
