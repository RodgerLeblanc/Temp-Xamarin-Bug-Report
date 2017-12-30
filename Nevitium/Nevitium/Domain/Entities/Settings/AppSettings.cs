
using CommonServiceLocator;
using Nevitium.Domain.Entities.Settings;

using Nevitium.Helpers.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;


namespace Nevitium.Domain.Entities.Settings
{
   

    public class AppSettings 
    {
       
        public List<Company> Companies { get; set; } = new List<Company>();

        public Company CurrentCompany { get; set; } = DependencyResolver.Resolve<Company>();
        public string Filename { get; set; } = "NucleusInvoice.json";
        private IJsonService _js;

       
        public void Save()
        {
            _js = _js ?? DependencyResolver.Resolve<IJsonService>();
            _js.SerializeToFile(this, Filename);
        }
       


    }
}
