using Nevitium.Domain.Entities.Settings;
using Nevitium.Helpers.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppSettingsView : ContentPage
	{
        private INavigationService _navigationService;

        public AppSettingsView (ConfigurationWrapper config, INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent ();
            BindingContext = config.AppSettings;
        }
        
        public void DataConnectionButton_Clicked(object sender, System.EventArgs e)
        {
            _navigationService.PushAsync(typeof(AppSettingsDataView), null);
            
        }
    }
}