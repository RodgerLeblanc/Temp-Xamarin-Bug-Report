using Nevitium.Domain.Entities.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppSettingsDataView : ContentPage
	{
	    public AppSettings AppSettings { get; set; }
		public AppSettingsDataView (ConfigurationWrapper config)
		{
            AppSettings = config.AppSettings;
            InitializeComponent ();
		    BindingContext = AppSettings;
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            AppSettings.Save();
        }

    }
}