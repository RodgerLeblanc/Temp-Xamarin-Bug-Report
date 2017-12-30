using CommonServiceLocator;
using Nevitium.Application.Facades;
using Nevitium.Domain.Entities.Settings;
using Nevitium.Helpers;
using Nevitium.Helpers.Services;
using Nevitium.Presentation.ViewModels;
using Nevitium.Presentation.Views;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace Nevitium.Test.Mocks
{
    class MockDependencyService
    {

        private static readonly UnityContainer Container = new UnityContainer();

        public static T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        public T BuildUp<T>(T obj)
        {
            return Container.BuildUp<T>(obj);
        }

        public MockDependencyService()
        {
            /* Models are not registered and are instantiated directly in the code */

            /* INTERFACE */
            Container.RegisterType<IInventoryDetailViewModel, InventoryDetailViewModel>();
            Container.RegisterType<IInventoryListViewModel, InventoryListViewModel>();
            Container.RegisterType<IInventoryImagesViewModel, InventoryImagesViewModel>();
            Container.RegisterType<INewCompanyViewModel, NewCompanyViewModel>();
            Container.RegisterType<INavigationService, MockNavigationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IJsonService, MockJsonService>();
            Container.RegisterType<IInjectableMessageService, InjectableMessageService>();
            Container.RegisterType<MockDatabaseContext>();


            /* CONCRETE */

            Container.RegisterType<InventoryFacade>();

            Container.RegisterType<MainView>();
            Container.RegisterType<MasterView>();
            Container.RegisterType<HomeView>();
            Container.RegisterType<NewCompanyView>();

            Container.RegisterType<InventoryDetailView>();
            Container.RegisterType<InventoryImagesView>();
            Container.RegisterType<InventoryListView>();

            Container.RegisterType<ContactsView>();
            Container.RegisterType<InvoiceView>();
            Container.RegisterType<LedgerView>();
            Container.RegisterType<ReportsView>();

            Container.RegisterType<AppSettingsDataView>();
            Container.RegisterType<AppSettingsView>();
            Container.RegisterType<CompanySettingsView>();
            Container.RegisterType<CompanySettingsWebServicesView>();

            /* CONCRETE Service models */
            Container.RegisterType<AppSettings>();
            Container.RegisterType<CompanySettings>();
            Container.RegisterType<ConfigurationWrapper>(new ContainerControlledLifetimeManager());


            /* Wire up ServiceLocator static */
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(Container));

        }


    }
}
