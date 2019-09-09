using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class ServerMonitorPage : ContentPage
    {
        public ServerMonitorPage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<ServerMonitorViewModel>();
        }
    }
}
