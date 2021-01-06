using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Windows;
using VNM2020.Models;
using VNM2020.Navigation;

namespace VNM2020.ViewModels
{
    class AddCategoryViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;

        public string newCategoryName = "";
        public string NewCategoryName { get => newCategoryName; set => Set(ref newCategoryName, value); }

        public AddCategoryViewModel(NavigationService navigationService)
        {            
            this.navigationService = navigationService;              
        }


        private RelayCommand<Window> addCategoryCommand;
        public RelayCommand<Window> AddCategoryCommand
        {
            get
            {
                return addCategoryCommand ?? (addCategoryCommand = new RelayCommand<Window>(
                    param =>
                    {                        
                        Core.Instance.AddCategory(NewCategoryName);
                        param.Close();
                    }
                    ,
                    param=>!String.IsNullOrWhiteSpace(NewCategoryName)
                ));
            }
        }


    }
}
