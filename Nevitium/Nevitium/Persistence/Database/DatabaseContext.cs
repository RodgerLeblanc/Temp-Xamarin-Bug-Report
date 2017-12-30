using Microsoft.EntityFrameworkCore;
using Nevitium.Domain.Entities.Inventory;
using Nevitium.Domain.Entities.Settings;
using Nevitium.Helpers;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nevitium.Persistence.Database
{
       
    public class DatabaseContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryMeta> InventoryMeta { get; set; }
        public DbSet<InventoryImage> InventoryImage { get; set; }
        public AppSettings _appSettings;

        public DatabaseContext(ConfigurationWrapper config)
        {
            _appSettings = config.AppSettings;
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_appSettings.CurrentCompany.Data.Database.Server == DatabaseService.DefaultSqlite)
            {
                var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath(_appSettings.CurrentCompany.Data.Database.Database + ".db");
                Debug.WriteLine(dbPath);
                optionsBuilder.UseSqlite($"Filename={dbPath}");

            }
            else
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
                {
                    DataSource = _appSettings.CurrentCompany.Data.Database.Server,
                    UserID = _appSettings.CurrentCompany.Data.Database.Username,
                    Password = _appSettings.CurrentCompany.Data.Database.Password,
                    InitialCatalog = _appSettings.CurrentCompany.Data.Database.Database,
                    ConnectTimeout = 10,
                    IntegratedSecurity = _appSettings.CurrentCompany.Data.Database.IntegratedSecurity
                };
                Debug.WriteLine(sb.ToString());
                optionsBuilder.UseSqlServer(sb.ToString(), null);
            }
        }
    }



}
