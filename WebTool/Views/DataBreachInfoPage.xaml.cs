using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class DataBreachInfoPage : ContentPage
    {
        public DataBreachInfoPage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<DataBreachInfoViewModel>();
        }
    }
}
