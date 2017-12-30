using Nevitium.Models;
using Nevitium.Presentation.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nevitium.Presentation.ViewModels
{
    class MasterViewModel : BaseViewModel
    {

        public ObservableCollection<MasterPageItem> Menu { get; set; } = new ObservableCollection<MasterPageItem>();
        public ICommand MenuItemSelectedCommand { get; private set; }
        

        public MasterViewModel() : base()
        {
            Menu.Add(
                 new MasterPageItem()
                 {
                     Title = "Home",
                     IconSource = "Assets/menu/Grid.png",
                     TargetType = typeof(HomeView)
                 }
                 );
         
            Menu.Add(
               new MasterPageItem()
               {
                   Title = "Inventory",
                   IconSource = "Assets/menu/inventory1.png",
                   TargetType = typeof(InventoryListView)
               }
               );
       

            MenuItemSelectedCommand = new Command<MasterPageItem>(MenuItemSelected);
        }

        void MenuItemSelected(MasterPageItem item)
        {            
            //App.RootPage.Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            //masterPage.ListView.SelectedItem = null;
            //App.RootPage.IsPresented = false;
        }
               

        private ImageSource DeviceSpecificFileLocation(string file)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.macOS:
                    return ImageSource.FromFile("Assets/menu/" + file);

                case Device.iOS:
                    return ImageSource.FromFile("Assets/menu/" + file);

                case Device.Android:
                    return ImageSource.FromFile("Assets/menu/" + file);

                case Device.UWP:
                    return ImageSource.FromFile("Assets/menu/" + file);

                default:
                    return ImageSource.FromFile("Assets/menu/" + file);
            }
        }

    }
}
