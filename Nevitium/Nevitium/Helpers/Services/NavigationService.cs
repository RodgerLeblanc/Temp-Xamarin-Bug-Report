// ***********************************************************************
// Assembly         : XLabs.Forms
// Author           : XLabs Team
// Created          : 12-27-2015
// 
// Last Modified By : XLabs Team
// Last Modified On : 01-04-2016
// ***********************************************************************
// <copyright file="NavigationService.cs" company="XLabs Team">
//     Copyright (c) XLabs Team. All rights reserved.
// </copyright>
// <summary>
//       This project is licensed under the Apache 2.0 license
//       https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/LICENSE
//       
//       XLabs is a open source project that aims to provide a powerfull and cross 
//       platform set of controls tailored to work with Xamarin Forms.
// </summary>
// ***********************************************************************
// 

using CommonServiceLocator;
using Nevitium.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nevitium.Helpers.Services
{


    public interface INavigationService
    {
        Task PopAsync(bool animated);
        Task PopModalAsync(bool animated);
        Task PushAsync(Type viewModelType, object parameter);
        Task PushModalAsync(Type viewModelType, object parameter);
        void SetDetailPage(Type viewModelType, object parameter);

        MasterDetailPage MasterDetail { get; set; }
        INavigation Navigation { get; }
    }
    public class NavigationService : INavigationService
    {
        private MasterDetailPage _masterDetail;
        public MasterDetailPage MasterDetail
        {
            get
            {
                return _masterDetail;
            }
            set
            {
                if (_masterDetail == value)
                {
                    return;
                }

                _masterDetail = value; Navigation = _masterDetail.Navigation;
            }
        }
        private INavigation _navigation;
        public INavigation Navigation { get => _navigation; private set => _navigation = value; }
        public void SetDetailPage(Type viewModelType, object parameter)
        {
            MasterDetail.Detail = new NavigationPage(CreatePage(viewModelType));
            Navigation = (MasterDetail.Detail as NavigationPage).RootPage.Navigation;
        }

        public async Task PushAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);

            await Navigation.PushAsync(page);

            if (parameter != null)
            {
                await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
            }
        }

        public async Task PushModalAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);

            await Navigation.PushModalAsync(page);

            if (parameter != null)
            {
                await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
            }

        }

        public async Task PopModalAsync(bool animated)
        {
            await Navigation.PopModalAsync(animated);
        }

        public async Task PopAsync(bool animated)
        {
            await Navigation.PopAsync(animated);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }
            Page page = DependencyResolver.Resolve<Page>(pageType);
            //Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }


    }
}