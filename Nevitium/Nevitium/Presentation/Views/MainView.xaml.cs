

using CommonServiceLocator;
using Nevitium.Helpers.Services;
using Nevitium.Models;
using Nevitium.Presentation.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevitium.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        private MasterPageItem masterItem;

        private INavigationService _navigationService;
        public MainView(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.MasterDetail = this;
            _navigationService.SetDetailPage(typeof(HomeView), null);

            //NavigationPage np = new NavigationPage(DependencyResolver.Resolve<HomeView>());

            //navigationService.Navigation = np.Navigation;
            
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
                        
            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
            
        }

       

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           //manually track selection an deselection and set colors on ???

            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                //NavigationPage np = new NavigationPage((Page) Activator.CreateInstance(item.TargetType));
                //NavigationPage np = new NavigationPage((Page)ServiceLocator.Current.GetInstance(item.TargetType));
                //.Navigation = np.RootPage.Navigation;
                //Detail = np;

                _navigationService.SetDetailPage(item.TargetType, null);

                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
                
            }

            
            
        }


    }
}