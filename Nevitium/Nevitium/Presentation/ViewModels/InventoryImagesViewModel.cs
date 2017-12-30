using Nevitium.Application.Facades;
using Nevitium.Helpers.Services;
using Nevitium.Domain.Entities.Inventory;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Nevitium.Presentation.ViewModels
{
    public interface IInventoryImagesViewModel
    {
        int InventoryId { get; set; }
        void Populate();
        event PropertyChangedEventHandler PropertyChanged;
    }

    public class InventoryImagesViewModel : BaseViewModel, IInventoryImagesViewModel
    {
        public ObservableCollection<InventoryImage> Images;
        public int InventoryId { get; set; }

        private readonly InventoryFacade _inventoryFacade;
        private readonly IInjectableMessageService _messageService;
        public InventoryImagesViewModel(InventoryFacade inventoryFacade, IInjectableMessageService messageService) : base()
        {
            _inventoryFacade = inventoryFacade;
            _messageService = messageService;
        }

        public async void Populate()
        {
            _messageService.Send(this, "DownloadingImages");
            //how do I make this cancellable?
            try
            {
                Images = await _inventoryFacade.GetInventoryImages(InventoryId);
            }
            catch (Exception e)
            {
                _messageService.Send(this, "DownloadFailed", e.Message);
            }

            _messageService.Send(this, "DownloadComplete");
        }


    }
}
