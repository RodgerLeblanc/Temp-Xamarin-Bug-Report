
using System;
using Nevitium.Helpers;
using Nevitium.Helpers.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanySettingsView : ContentPage
	{


	    private INavigationService _navigationService;

		public CompanySettingsView (INavigationService navigationService)
		{
		    _navigationService = navigationService;
            InitializeComponent ();            
           
		}

        public void InvoiceSettingsButton_Clicked(Object sender, System.EventArgs e)
        {

        }

        public void DataServicesButton_Clicked(Object sender, System.EventArgs e)
        {
            _navigationService.PushAsync(typeof(CompanySettingsWebServicesView), null);
            
        }


    }
}