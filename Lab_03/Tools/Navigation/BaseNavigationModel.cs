﻿using System.Collections.Generic;
using System.Windows;

namespace KMA.CSharp2020.Lab03.Tools.Navigation
{
    abstract class BaseNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner { get { return _contentOwner; } }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            if (ViewsDictionary[viewType] is KMA.CSharp2020.Lab03.Tools.Navigation.IUpdateable)
            {
                ((IUpdateable)ViewsDictionary[viewType]).Update();
            }
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }
        protected abstract void InitializeView(ViewType viewType);
    }
}