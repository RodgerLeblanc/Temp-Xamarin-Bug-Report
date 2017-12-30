using Nevitium.Helpers.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nevitium.Presentation.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigationService _navigationService;

        public BaseViewModel()
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
            
        }

    }
}
