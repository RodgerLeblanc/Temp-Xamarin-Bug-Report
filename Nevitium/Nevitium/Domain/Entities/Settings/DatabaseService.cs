
namespace Nevitium.Domain.Entities.Settings
{
    public class DatabaseService
    {

        public static string DefaultSqlite = "integrated";
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }

    }
}
