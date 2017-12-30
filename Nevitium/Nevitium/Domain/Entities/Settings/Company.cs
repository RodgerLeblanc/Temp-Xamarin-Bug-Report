

namespace Nevitium.Domain.Entities.Settings
{
    public class Company
    {
        public Company()
        {
           
        }

        public string Name { get; set; }
       
        public DataConnection Data { get; set; } = new DataConnection();


    }
}
