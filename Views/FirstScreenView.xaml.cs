using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VNM2020.Services;

namespace VNM2020.Views
{
    /// <summary>
    /// Interaction logic for FirstScreenView.xaml
    /// </summary>
    public partial class FirstScreenView : UserControl
    {
        public FirstScreenView()
        {
            InitializeComponent();
        }

        
        private void MapViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
           
            if (sender is ScrollViewer && !e.Handled)
            {
               
                e.Handled = true;
                DragEngine.Instance.MapScrollUp(sender, e);
            }
        }
    }


}
