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
        public ICommand CheckAccountCommand => new Command(CheckAccount);

        public DataBreachViewModel()
        {
        }

        private async void CheckAccount()
        {
            try
            {
                var dataBreachCenter = new DataBreachService();

                Results = await dataBreachCenter.CheckAccountAsync(Account);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
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
