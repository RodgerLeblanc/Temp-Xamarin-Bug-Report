
using System.Collections.Generic;
using Nevitium.Helpers.Services;

namespace Nevitium.Domain.Entities.Settings
{
    public class CompanySettings
    {
       

        public string Filename { get; set; }

        public string Name { get; set; }
        public string Currency { get; set; }
        public string InvoiceNumber { get; set; } = "10000";
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public WebServices WebServices { get; set; } = new WebServices();
        private IJsonService _js;

        public CompanySettings()
        {
            
        }

        public void Save()
        {
            _js = _js ?? DependencyResolver.Resolve<IJsonService>();
            _js.SerializeToFile(this, Filename);
        }
        
    }
}
