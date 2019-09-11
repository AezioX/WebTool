using WebTool.ViewModels;
using Xamarin.Forms;

namespace WebTool.Views
{
    public partial class ServerListPage : ContentPage
    {
        public ServerListPage()
        {
            InitializeComponent();

            BindingContext = AppContainer.Resolve<ServerListViewModel>();
        }
    }
}
