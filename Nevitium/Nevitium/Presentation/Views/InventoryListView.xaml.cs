
using Nevitium.Helpers.Services;
using Nevitium.Presentation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryListView : ContentPage
    {

        private IInventoryListViewModel _viewModel;
        private INavigationService _navigationService;
        public InventoryListView(IInventoryListViewModel viewModel, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            InitializeComponent();
            
            BindingContext = _viewModel;
            SearchPicker.SelectedItem = "Short Description";

            this.ToolbarItems.Add(new ToolbarItem() { Icon= FileLocatorService.DeviceSpecificFileLocation("icons8_Plus_Math_32px.png") });
           
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SearchFilter((string)SearchPicker.SelectedItem, (SearchBar)sender);
        }


        private void NewButton_Clicked(object sender, System.EventArgs e)
        {
            _navigationService.PushAsync(typeof(InventoryDetailView), null);
                        
        }
           
      

        protected override void OnAppearing()
        {
            _viewModel?.Refresh();
        }

    }
}