using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class DomainDatabasePage : ContentPage
    {
        public DomainDatabasePage()
        {
            InitializeComponent();

            BindingContext = new DomainDatabaseViewModel();
        }
    }
}
