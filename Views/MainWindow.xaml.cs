using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using VNM2020.Messaging;
using VNM2020.Models;
using VNM2020.ViewModels;

namespace VNM2020.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Core.Instance.waitingVisibility = Visibility.Visible;
            Messenger.Default.Send<UIMessage>(new UIMessage { PropName = "WaitingVisibility" });
            Core.Instance.UpdateSettings();
            for (int i = 0; i < Core.Instance.allHosts.Count; i++)
            {
                Core.Instance.UpdateHost(Core.Instance.allHosts[i]);
            }

            if (GlobalSettings.Instance.ClearOnQuit)
            {
                Core.Instance.ClearActions();
                e.Cancel = true;
            }
            else
            {
                Application.Current.Shutdown();
            }

        }
    }
}
