using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<HomeViewModel>();
        }
    }
}
