
using System.Threading.Tasks;
using Nevitium.Application.Facades;

namespace Nevitium.Test.Mocks
{
   
    public class MockInventoryFacade : InventoryFacade
    {        
        public MockInventoryFacade(MockDatabaseContext databaseContext) : base(databaseContext)
        {
         
        }


    }
}
