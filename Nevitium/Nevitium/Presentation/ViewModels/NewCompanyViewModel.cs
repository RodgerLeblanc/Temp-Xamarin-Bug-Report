using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Nevitium.Helpers;
using Nevitium.Domain.Entities.Settings;

namespace Nevitium.Presentation.ViewModels
{
    public interface INewCompanyViewModel
    {
        CompanySettings CompanySettings { get; set; }
        ICommand NewCompanyCommand { get; }
        event PropertyChangedEventHandler PropertyChanged;
    }

    public class NewCompanyViewModel : BaseViewModel, INewCompanyViewModel
    {

        public CompanySettings CompanySettings { get; set; }
        private readonly  DatabaseService _databaseService;
        
        
        public ICommand NewCompanyCommand { get; private set; }

        private ConfigurationWrapper _config;

        public NewCompanyViewModel(ConfigurationWrapper config, DatabaseService ds) : base()
        {
            _config = config;
            CompanySettings = config.CompanySettings;            
            _databaseService = ds;
            NewCompanyCommand = new Command(CreateNewCompany);
        }

        private void CreateNewCompany()
        {
            //if (CompanyName.Text == "" || InvoiceNumber.Text == "")
            //{
            //    return;
            //}

            /* Create new company and app settings file */

            if (CompanySettings.Name == null)
            {
                //TODO: send message
                return;
            }

            _config.AppSettings.CurrentCompany.Name = CompanySettings.Name;

            var company = _config.AppSettings.Companies.Find(x => x.Name.Equals(_config.AppSettings.CurrentCompany.Name));
            if (company == null)
            {
                _config.AppSettings.Companies.Add(_config.AppSettings.CurrentCompany);
            }

            _config.AppSettings.CurrentCompany.Data.Database = _databaseService; 

            _databaseService.Server = DatabaseService.DefaultSqlite;
            _databaseService.Database = _config.AppSettings.CurrentCompany.Name;

            _config.AppSettings.Save();

            CompanySettings.Name = _config.AppSettings.CurrentCompany.Name;
            CompanySettings.InvoiceNumber = CompanySettings.InvoiceNumber;
            CompanySettings.Filename = _config.AppSettings.CurrentCompany.Name + ".json";
            CompanySettings.Save();

            _navigationService.PopModalAsync(true);
        }
    }
}