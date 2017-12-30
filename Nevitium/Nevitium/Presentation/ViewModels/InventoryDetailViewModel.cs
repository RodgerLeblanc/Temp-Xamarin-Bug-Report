using Nevitium.Application.Facades;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Nevitium.Helpers.Services;
using Xamarin.Forms;
using Nevitium.Domain.Entities.Inventory;
using System.Threading.Tasks;

namespace Nevitium.Presentation.ViewModels
{
    public interface IInventoryDetailViewModel
    {
        Inventory Inventory { get; set; }
        ICommand SaveCommand { get; }
        ICommand CancelCommand { get; }
        event PropertyChangedEventHandler PropertyChanged;
    }

    public class InventoryDetailViewModel : BaseViewModel, IInventoryDetailViewModel
    {

        public Inventory Inventory { get; set; } = new Inventory();

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        private readonly InventoryFacade _inventoryFacade;
        private IInjectableMessageService _messageService;

        public InventoryDetailViewModel(InventoryFacade inventoryFacade, IInjectableMessageService messageService) : base()
        {
            _inventoryFacade = inventoryFacade;
            _messageService = messageService;
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
        }

        public override async Task InitializeAsync(object parameter)
        {
            IsBusy = true;

            //take parameter and do a bunch of stuff with data to prepare model from parameter passed in during navigation
            Inventory = (Inventory)parameter;
            OnPropertyChanged("Inventory");

            IsBusy = false;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(Inventory.ShortDescription))
            {

                _messageService.Send(this, "ShortDescriptionMissing");
                
                return false;
            }

            return true;
        }

        private async void Save()
        {
            if (ValidateForm() == false)
            {
                return;
            }
                      
            
            _messageService.Send(this, "DisableSave");
            try
            {
                await _inventoryFacade.SaveAsync(Inventory);
            }
            catch (Exception e)
            {
                _messageService.Send(this, "SaveFailed", e.Message);                
            }

            Inventory = new Inventory();                    
            OnPropertyChanged("Inventory");
            _messageService.Send(this, "EnableSave");

        }

        private void Cancel()
        {

            _navigationService.PopAsync(true);
            //Inventory = new Inventory();
            //OnPropertyChanged("Inventory");
        }


    }
}
