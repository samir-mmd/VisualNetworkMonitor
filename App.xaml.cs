using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VNM2020.Navigation;
using VNM2020.Views;

namespace VNM2020
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var locator = new ViewModelLocator();

            var window = new MainWindow();
            window.DataContext = locator.MainViewModel;
            window.ShowDialog();
        }
    }
}
