using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNM2020.Navigation
{
    public class NavigationService
    {
        Dictionary<string, ViewModelBase> pages = new Dictionary<string, ViewModelBase>();

        public void GoTo(string name)
        {
            Messenger.Default.Send(pages[name]);
        }

        public void RegisterPage(string name, ViewModelBase vm)
        {
            pages.Add(name, vm);
        }
    }
}
