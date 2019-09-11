using System;
using System.Collections.Generic;
using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class ServerListAddPage : ContentPage
    {
        public ServerListAddPage()
        {
            InitializeComponent();

            BindingContext = new ServerListAddViewModel();
        }
    }
}
