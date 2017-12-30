using Nevitium.Helpers.Services;
using Nevitium.Presentation.Localization.Resources;
using Nevitium.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Nevitium.Presentation.Views
{
    public partial class MasterView : ContentPage
    {
        public ListView ListView
        {
            get { return listView; }
        }

        public MasterView()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Home,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Home_64px.png"),
                TargetType = typeof(HomeView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Connections,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Contact_Details_64px.png"),
                TargetType = typeof(ContactsView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Inventory,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Barcode_Reader_64px.png"),
                TargetType = typeof(InventoryListView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.POSMode,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Cash_Register_64px.png"),
                TargetType = typeof(InvoiceView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Invoices,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Bill_64px.png"),
                TargetType = typeof(InvoiceView)
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Ledger,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Money_64px.png"),
                TargetType = typeof(LedgerView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.Reports,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Combo_Chart_64px.png"),
                TargetType = typeof(ReportsView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.CompanySettings,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Slider__64px.png"),
                TargetType = typeof(CompanySettingsView)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.AppSettings,
                IconSource = FileLocatorService.DeviceSpecificFileLocation("icons8_Settings_64px.png"),
                TargetType = typeof(AppSettingsView)
            });

            listView.ItemsSource = masterPageItems;

        }


    }
}
