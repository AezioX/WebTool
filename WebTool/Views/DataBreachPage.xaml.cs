using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class DataBreachPage : ContentPage
    {
        public DataBreachPage()
        {
            InitializeComponent();

            BindingContext = new DataBreachViewModel();
        }
    }
}
