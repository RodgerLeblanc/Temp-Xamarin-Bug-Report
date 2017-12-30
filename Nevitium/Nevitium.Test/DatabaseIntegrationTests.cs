using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nevitium.Domain.Entities.Inventory;
using Nevitium.Domain.Entities.Settings;
using Nevitium.Test.Mocks;

namespace Nevitium.Text
{
    [TestClass]
    public class DatabaseIntegrationTests
    {

        private string _databaseFile = "TestDatabase.db";

        private MockDependencyService IoC;
        [TestInitialize()]
        public void Initialize()
        {

            if (File.Exists(_databaseFile))
            {
                File.Delete(_databaseFile);
            }

            Xamarin.Forms.Mocks.MockForms.Init();

            IoC = new MockDependencyService();

        }

        [TestCleanup()]
        public void Cleanup()
        {
            if (File.Exists(_databaseFile))
            {
                File.Delete(_databaseFile);
            }
        }

        [TestMethod]
        public async Task CanSaveAndRetrieveInventoryFromSqlite()
        {
            var config = MockDependencyService.Resolve<ConfigurationWrapper>();

            config.AppSettings.CurrentCompany.Data.Database.Database = _databaseFile;
            config.AppSettings.CurrentCompany.Data.Database.Server = DatabaseService.DefaultSqlite;

            MockInventoryFacade facade = MockDependencyService.Resolve<MockInventoryFacade>();

            Inventory inv = new Inventory();

            inv.ShortDescription = "TestItem";

            await facade.SaveAsync(inv);

            var result = await facade.GetByIdAsync(inv.Id);
            
            Assert.AreEqual(result.Id, inv.Id);
        }


    }
}
