using newsmobileapp.Models;
using Xamarin.Forms;

namespace newsmobileapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var analyticsService = DependencyService.Get<IAnalyticsManager>();
            analyticsService.LogEvent("sample_event");
        }
    }
}
