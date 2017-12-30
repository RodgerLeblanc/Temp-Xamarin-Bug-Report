using Microsoft.EntityFrameworkCore;
using Nevitium.Domain.Entities.Settings;
using System.Diagnostics;


namespace Nevitium.Test.Mocks
{  
    public sealed class DatabaseContext : Persistence.Database.DatabaseContext
    {
        public DatabaseContext(ConfigurationWrapper config) : base(config)
        {
                
        }      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_appSettings.CurrentCompany.Data.Database.Server == DatabaseService.DefaultSqlite)
            {
                var dbPath = _appSettings.CurrentCompany.Data.Database.Database+".db";
                Debug.WriteLine(dbPath);
                optionsBuilder.UseSqlite($"Filename={dbPath}");
                return;
            }
           
        }
    }
}




