using Nevitium.Helpers;
using Nevitium.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nevitium.Test.Mocks
{
    class MockNavigationService : INavigationService
    {
        public INavigation Navigation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MasterDetailPage MasterDetail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, bool animated = true, params object[] args)
        {
            throw new NotImplementedException();
        }

        public object NavigateTo(Type pageType, bool animated = true, params object[] args)
        {
            throw new NotImplementedException();
        }

        public T NavigateTo<T>(bool animated = true, params object[] args) where T : class
        {
            throw new NotImplementedException();
        }

        public Task PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public void PopModalAsync()
        {
            return;
        }

        public Task PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public void RegisterPage(string pageKey, Type pageType)
        {
            throw new NotImplementedException();
        }

        public void SetDetailPage(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
