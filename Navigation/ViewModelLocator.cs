using System;
using System.Collections.Generic;
using System.Text;
using VNM2020.ViewModels;

namespace VNM2020.Navigation
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; set; }
        public DialogViewModel DialogViewModel { get; set; }
        public LogScreenWindowViewModel LogScreenWindowViewModel { get; set; }

        public FirstScreenViewModel FirstScreenViewModel { get; set; }
        public AddHostViewModel AddHostViewModel { get; set; }
        public AddCategoryViewModel AddCategoryViewModel { get; set; }
        public EditCategoryViewModel EditCategoryViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }
        public LogScreenViewModel LogScreenViewModel { get; set; }
       
        public NavigationService Navigation { get; set; }

        public ViewModelLocator()
        {
            Navigation = new NavigationService();

            MainViewModel = new MainViewModel();
            DialogViewModel = new DialogViewModel();
            LogScreenWindowViewModel = new LogScreenWindowViewModel();


            FirstScreenViewModel = new FirstScreenViewModel(Navigation);
            AddHostViewModel = new AddHostViewModel(Navigation);
            AddCategoryViewModel = new AddCategoryViewModel(Navigation);
            EditCategoryViewModel = new EditCategoryViewModel(Navigation);
            SettingsViewModel = new SettingsViewModel(Navigation);
            LogScreenViewModel = new LogScreenViewModel(Navigation);
          

            Navigation.RegisterPage("FirstScreen", FirstScreenViewModel);
            Navigation.RegisterPage("AddHost", AddHostViewModel);
            Navigation.RegisterPage("AddCategory", AddCategoryViewModel);
            Navigation.RegisterPage("EditCategory", EditCategoryViewModel);
            Navigation.RegisterPage("Settings", SettingsViewModel);
            Navigation.RegisterPage("LogScreen", LogScreenViewModel);           
            Navigation.GoTo("FirstScreen");
        }
    }
}
