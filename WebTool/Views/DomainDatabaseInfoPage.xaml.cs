using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class DomainDatabaseInfoPage : ContentPage
    {
        public DomainDatabaseInfoPage()
        {
            InitializeComponent();

            BindingContext = new DomainDatabaseInfoViewModel();
        }
    }
}
