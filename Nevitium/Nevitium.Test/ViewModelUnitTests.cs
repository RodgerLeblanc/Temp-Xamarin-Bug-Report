using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nevitium.Domain.Entities.Settings;
using Nevitium.Presentation.ViewModels;
using Nevitium.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevitium.Test
{
    [TestClass]
    public class ViewModelUnitTests
    {

        private MockDependencyService IoC;
        [TestInitialize()]
        public void Initialize()
        {    
            Xamarin.Forms.Mocks.MockForms.Init();
            IoC = new MockDependencyService();
        }


        [TestMethod]
        public void DoesNewCompanyViewModelCreateCompanyFillCompanyProperties()
        {
            var config = MockDependencyService.Resolve<ConfigurationWrapper>();

            var model = MockDependencyService.Resolve<INewCompanyViewModel>();

            model.CompanySettings.Name = "Nucleus Mobile LLC";
            model.CompanySettings.InvoiceNumber = "10000";

            model.NewCompanyCommand.Execute(null);

            Assert.AreEqual(config.CompanySettings.Name, "Nucleus Mobile LLC");
            Assert.AreEqual(config.CompanySettings.InvoiceNumber, "10000");
            Assert.AreEqual(config.CompanySettings.Filename, "Nucleus Mobile LLC.json");


        }



    }
}
