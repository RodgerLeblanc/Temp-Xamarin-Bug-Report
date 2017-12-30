using System;
using Nevitium.Helpers.Services;
using Nevitium.Presentation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Nevitium.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryDetailView : ContentPage
    {
        
        public IInventoryDetailViewModel _inventoryDetailModel;

        private IInjectableMessageService _messageService;

        public InventoryDetailView(IInventoryDetailViewModel inventoryDetailModel, IInjectableMessageService messageService) 
        {

            _inventoryDetailModel = inventoryDetailModel;
            _messageService = messageService;

            InitializeComponent();
            BindingContext = _inventoryDetailModel;

            if (_inventoryDetailModel.Inventory.Id == 0)
            {
                //make changes based on new
            }
                 
            _messageService.Subscribe(this, "DisableSave",
                (sender) =>
                {
                    SaveButton.IsEnabled = false;
                    SaveButton.Text = "Saving...";
                });
            _messageService.Subscribe(this, "EnableSave",
                (sender) =>
                {
                    SaveButton.IsEnabled = true;
                    SaveButton.Text = "Save";
                });
            _messageService.Subscribe<InventoryDetailView, string>(this, "SaveFailed",  
                (sender, arg) =>
                {
                    DisplayAlert("Database Problem", arg, "OK");
                    SaveButton.IsEnabled = true;
                    SaveButton.Text = "Save";
                });

        }
     
        public void OnlineUpcSearch_Clicked(Object sender, System.EventArgs e)
        {
            //search online
            
        }

        public void OnlineEanSearch_Clicked(Object sender, System.EventArgs e)
        {
            //search online
        }

        public void OnlineAsinSearch_Clicked(Object sender, System.EventArgs e)
        {
            //search online
        }

        public void OnlineIsbnSearch_Clicked(Object sender, System.EventArgs e)
        {
            //search online
        }


        public void ServiceToggle_Toggled(Object sender, System.EventArgs e)
        {
            var toggle =  (Switch)sender;

            var visible = !toggle.IsToggled;

            //UpcRegion.IsVisible = visible;
            //UpcLabel.IsVisible = visible;
            //UpcCodeEntry.IsVisible = visible;

            SizeLabel.IsVisible = visible;
            SizeEntry.IsVisible = visible;
            
            WeightLabel.IsVisible = visible;
            WeightEntry.IsVisible = visible;

            QtyLabel.IsVisible = visible;
            QuantityEntry.IsVisible = visible;

            ReorderLabel.IsVisible = visible;
            ReorderEntry.IsVisible = visible;

            PartialLabel.IsVisible = visible;

            AllowPartialToggle.IsVisible = visible;
            //TODO: Change category listing
        }

       
        protected override bool OnBackButtonPressed()
        {

            return false;

        }



    }

}