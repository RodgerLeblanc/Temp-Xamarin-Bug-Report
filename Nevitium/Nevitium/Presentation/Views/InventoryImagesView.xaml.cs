
using Nevitium.Presentation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryImagesView : ContentPage
	{
	    public IInventoryImagesViewModel _viewModel;

		public InventoryImagesView (IInventoryImagesViewModel viewModel)
		{
		    _viewModel = viewModel;
            InitializeComponent ();
		    BindingContext = _viewModel;
		}
	}
}