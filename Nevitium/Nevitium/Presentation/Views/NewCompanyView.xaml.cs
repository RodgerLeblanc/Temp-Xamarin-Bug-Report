using Nevitium.Helpers.Services;
using Nevitium.Presentation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCompanyView : ContentPage
	{

	    private readonly INewCompanyViewModel _viewModel;
        
        public NewCompanyView (INewCompanyViewModel viewModel)
        {
            _viewModel = viewModel;
			InitializeComponent ();
            AppLogo.Source = FileLocatorService.DeviceSpecificFileLocation("nucleus_invoice_320.png");
            BindingContext = _viewModel;
        }


    }
}