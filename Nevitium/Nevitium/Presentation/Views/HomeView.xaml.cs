using CommonServiceLocator;
using Nevitium.Domain.Entities.Settings;
using Nevitium.Helpers;
using Nevitium.Helpers.Services;
using Nevitium.Presentation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {       

        public HomeView(ConfigurationWrapper config, INavigationService navigationService)
        {
            
            InitializeComponent();

            AppLogo.Source = FileLocatorService.DeviceSpecificFileLocation("nucleus_invoice_320.png");
                        
            Icon = FileLocatorService.DeviceSpecificFileLocation("icons8_Home_64px.png");

            if (config.AppSettings.CurrentCompany.Name == null)
            {
                navigationService.PushModalAsync(typeof(NewCompanyViewModel), null);
                
            }

        }

       

    }
}