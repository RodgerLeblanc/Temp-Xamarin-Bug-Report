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

using System;
using Xamarin.Forms;

namespace Nevitium.Helpers
{
    public interface INavigationService
    {
        Xamarin.Forms.INavigation Navigation { get; set; }

        void RegisterPage(string pageKey, Type pageType);

        void PopModalAsync();


        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentException">That pagekey is not registered;pageKey</exception>
        void NavigateTo(string pageKey, bool animated = true, params object[] args);
        
        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentException">Argument must be derived from type Xamarin.Forms.Page;pageType</exception>
        object NavigateTo(Type pageType, bool animated = true, params object[] args);
       
        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentException">Page Type must be based on Xamarin.Forms.Page</exception>
        T NavigateTo<T>(bool animated = true, params object[] args) where T : class;


        /// <summary>
        /// Goes back.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Goes forward.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        void GoForward();

    }
}