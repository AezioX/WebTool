using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = new SettingsViewModel();
        }
    }
}
