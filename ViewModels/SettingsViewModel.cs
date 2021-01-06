using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VNM2020.Messaging;
using VNM2020.Models;
using VNM2020.Navigation;
using VNM2020.Services;

namespace VNM2020.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
      
        public string MailServer { get => GlobalSettings.Instance.mailServer; set => Set(ref GlobalSettings.Instance.mailServer, value); }     
        public int MailPort { get => GlobalSettings.Instance.mailPort; set => Set(ref GlobalSettings.Instance.mailPort, value); }    
        public bool EnableSSL { get => GlobalSettings.Instance.enableSSL; set => Set(ref GlobalSettings.Instance.enableSSL, value); }      
        public string MailFrom { get => GlobalSettings.Instance.mailFrom; set => Set(ref GlobalSettings.Instance.mailFrom, value); }      
        public string MailPass { get => GlobalSettings.Instance.mailPass; set => Set(ref GlobalSettings.Instance.mailPass, value); }        
        public string MailTo { get => GlobalSettings.Instance.mailTo; set => Set(ref GlobalSettings.Instance.mailTo, value); }      
        public bool EnableNotifications { get => GlobalSettings.Instance.enableNotifications; set => Set(ref GlobalSettings.Instance.enableNotifications, value); }     
        public bool EnableLog { get => GlobalSettings.Instance.enableLog; set => Set(ref GlobalSettings.Instance.enableLog, value); }      
        public bool ShuffleOnStartUp { get => GlobalSettings.Instance.shuffleOnStartUp; set => Set(ref GlobalSettings.Instance.shuffleOnStartUp, value); }
        public bool ClearOnQuit { get => GlobalSettings.Instance.clearOnQuit; set => Set(ref GlobalSettings.Instance.clearOnQuit, value); }



        public ObservableCollection<string> mapList = new ObservableCollection<string>();
        public ObservableCollection<string> MapList { get => mapList; set => Set(ref mapList, value); }

        public string Picpath
        {
            get => GlobalSettings.Instance.picpath;
            set
            {
                Set(ref GlobalSettings.Instance.picpath, value);
                Messenger.Default.Send(new UIMessage { PropName = "MapImage" });                
                MessageBoxResult result = MessageBox.Show($"Normalize Positions of Hosts that do not fit new map?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                GlobalSettings.Instance.SetMapLimits();
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var item in Core.Instance.allHosts)
                    {
                        if (item.Colnumber > GlobalSettings.Instance.horizontalLimit)
                        {
                            item.Colnumber = GlobalSettings.Instance.horizontalLimit - 10;
                        }

                        if (item.Rownumber > GlobalSettings.Instance.verticalLimit)
                        {
                            item.Rownumber = GlobalSettings.Instance.verticalLimit - 10;
                        }
                    }
                }
            }
        }

        public SettingsViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;

            var tempList = Directory.GetFiles(@"Maps\", "*.png*").Select(Path.GetFileName).Union(Directory.GetFiles(@"Maps\", "*.jpg*").Select(Path.GetFileName)).ToArray();
            foreach (var item in tempList)
            {
                MapList.Add(item);
            }
        }

        private RelayCommand openMapFolderCommand;
        public RelayCommand OpenMapFolderCommand
        {
            get
            {
                return openMapFolderCommand ?? (openMapFolderCommand = new RelayCommand(
                    () =>
                    {                       
                        Process.Start("explorer.exe", System.IO.Directory.GetCurrentDirectory()+"\\Maps");
                    }
                ));
            }
        }

        private RelayCommand testMailSettingsCommand;
        public RelayCommand TestMailSettingsCommand
        {
            get
            {
                return testMailSettingsCommand ?? (testMailSettingsCommand = new RelayCommand(
                     async () =>
                    {
                        await Task.Run(() =>
                        {                            
                            string messagebody = "";
                            messagebody += $"----MAIL SETTINGS----\n" +
                            $"Mail Server {MailServer}\n" +
                        $"Port {MailPort}\n" +
                        $"SSL {EnableSSL}\n" +
                        $"Login {MailFrom}\n" +
                        $"Password {MailPass}\n" +
                        $"Default recipient {MailTo}";
                            NotificationService.SendMail($"Test Email {DateTime.Now}", messagebody, MailTo);
                        });
                    }
                    ,
                     ()=> !String.IsNullOrWhiteSpace(MailTo) && !String.IsNullOrWhiteSpace(MailFrom) && !String.IsNullOrWhiteSpace(MailPass) && !String.IsNullOrWhiteSpace(MailServer) && MailPort>0 && NotificationService.IsValidEmail(MailTo)
                ));
            }
        }
    }
}
