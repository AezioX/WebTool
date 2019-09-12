using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class ServerListAddPage : ContentPage
    {
        public ServerListAddPage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<ServerListAddViewModel>();
        }
    }
}
