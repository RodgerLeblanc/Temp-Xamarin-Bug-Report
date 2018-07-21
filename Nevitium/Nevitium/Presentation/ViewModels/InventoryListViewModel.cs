
using Nevitium.Application.Facades;
using Nevitium.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Nevitium.Presentation.Views;
using Xamarin.Forms;
using Nevitium.Domain.Entities.Inventory;
using System.Diagnostics;

namespace Nevitium.Presentation.ViewModels
{
    public interface IInventoryListViewModel
    {
        ObservableCollection<Inventory> InventoryList { get; set; }
        ICommand RefreshCommand { get; }
        ICommand NewInventoryCommand { get; }
        ICommand ItemSelectedCommand { get; }
        Task Populate();
        void HandleItemSelected(Inventory item);
        void Refresh();
        void SearchFilter(string column, SearchBar entry);
        event PropertyChangedEventHandler PropertyChanged;
    }

    public class InventoryListViewModel : BaseViewModel, IInventoryListViewModel
    {
        public ObservableCollection<Inventory> InventoryList { get; set; }
        ObservableCollection<Inventory> TheData { get; set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand NewInventoryCommand { get; private set; }
        public ICommand ItemSelectedCommand { get; private set; }

        public Inventory SelectedItem { get; set; }

        private InventoryFacade _inventoryFacade;


        public InventoryListViewModel(InventoryFacade inventoryFacade) : base()
        {
            
            _inventoryFacade = inventoryFacade;

            RefreshCommand = new Command(Refresh);
            ItemSelectedCommand = new Command<Inventory>(HandleItemSelected);
        }

        public async Task Populate()
        {
            TheData = await _inventoryFacade.GetAllItemsAsync();
            InventoryList = TheData;
            OnPropertyChanged("InventoryList");
            
        }

        public void HandleItemSelected(Inventory item)
        {
            if (item == null)
                return;

            Debug.WriteLine("ListViewHandleItem FIRED ***************");
            _navigationService.PushAsync(typeof(InventoryDetailViewModel), item);

            SelectedItem = null;
            OnPropertyChanged(nameof(SelectedItem));
        }

        public async void Refresh()
        {
            await Populate();
        }

        public void SearchFilter(string column, SearchBar entry)
        {
            IEnumerable<Inventory> list = new List<Inventory>();

            switch (column)
            {
                case "Short Description":
                    list = TheData.Where(x => x.ShortDescription.ToUpper().Contains(entry.Text.ToUpper()));
                    break;
                case "UPC Code":
                    list = TheData.Where(x => x.UPCA.ToUpper().Contains(entry.Text.ToUpper()));
                    break;
                case "Custom Code":
                    list = TheData.Where(x => x.CustomCode.ToUpper().Contains(entry.Text.ToUpper()));
                    break;
                default:
                    break;
            }

            if (!list.Any())
            {
                entry.TextColor = Color.Red;
                return;
            }
            else
            {
                entry.TextColor = Color.Green;
            }
            InventoryList = new ObservableCollection<Inventory>(list);

            OnPropertyChanged("InventoryList");


        }


    }
}
