

using Nevitium.Helpers.Services;
using Newtonsoft.Json;

namespace Nevitium.Domain.Entities.Settings
{
    public class DataConnection 
    {
        public DataConnection()
        {
            
        }

        public DatabaseService Database { get; set; } = new DatabaseService();
        public WebService NucleusWebService { get; set; } = new WebService();


    }
}
