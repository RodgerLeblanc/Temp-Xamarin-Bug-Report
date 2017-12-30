using Nevitium.Domain.Entities.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanySettingsWebServicesView : ContentPage
	{

	    private readonly CompanySettings _companySettings;
        
        public CompanySettingsWebServicesView (ConfigurationWrapper config)
        {
            _companySettings = config.CompanySettings;

            InitializeComponent ();
            BindingContext = _companySettings.WebServices;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _companySettings.Save();
        }


    }
}