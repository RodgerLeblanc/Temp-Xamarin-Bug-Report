using Nevitium.Domain.Entities.Settings;
using Nevitium.Helpers.Services;
using Nevitium.Presentation.Localization;
using Nevitium.Presentation.Localization.Resources;
using Nevitium.Presentation.Views;
using System.Globalization;
using Xamarin.Forms;

namespace Nevitium
{
    public partial class App : Xamarin.Forms.Application
    {   
        public static INavigationService NavigationService;
        public static DependencyResolver IoC;
        public App()
        {
            IoC = new DependencyResolver();

            var config = DependencyResolver.Resolve<ConfigurationWrapper>();
            
            MainPage = DependencyResolver.Resolve<MainView>();

        }


        public static CultureInfo Culture { get; set; } = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        public void SwitchLanguage(string code)  //allows the user to set or override current culture language
        {
            var cultureInfo = new CultureInfo(code);
            Culture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            AppResources.Culture = cultureInfo;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
