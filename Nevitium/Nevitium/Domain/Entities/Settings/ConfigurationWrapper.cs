using Nevitium.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevitium.Domain.Entities.Settings
{
    public class ConfigurationWrapper
    {

        public AppSettings AppSettings;
        public CompanySettings CompanySettings;

        public ConfigurationWrapper(IJsonService jsonService)
        {           
            AppSettings = jsonService.DeserializeFromFile<AppSettings>(AppSettings, "NucleusInvoice.json");
                     

            if (AppSettings.CurrentCompany != null)
            {                
                CompanySettings = jsonService.DeserializeFromFile<CompanySettings>(CompanySettings, AppSettings.CurrentCompany.Name + ".json");
                
            }


        }
        

    }
}
