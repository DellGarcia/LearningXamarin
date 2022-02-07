using AwesomeApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using XamWebApiClient;

namespace AwesomeApp.Pages
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            BindingContext = 
                Startup.ServiceProvider.GetService<TestViewModel>();
        }
    }
}