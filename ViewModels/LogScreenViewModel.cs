using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using VNM2020.Messaging;
using VNM2020.Models;
using VNM2020.Navigation;
using VNM2020.Services;

namespace VNM2020.ViewModels
{
    class LogScreenViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;

        private DateTime logDate = DateTime.Now;
        public DateTime LogDate { get => logDate; set => Set(ref logDate, value); }

        private string logSearch;
        public string LogSearch { get => logSearch; set => Set(ref logSearch, value); }

        public ObservableCollection<LogMessage> MainLog
        {
            get => Core.Instance.mainLog;
            set => Set(ref Core.Instance.mainLog, value);
        }

        public ICollectionView MainLogView { get; private set; }

        public LogScreenViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;
            MainLogView = CollectionViewSource.GetDefaultView(MainLog);

            Messenger.Default.Register<UIMessage>(this, param =>
            {                
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    RaisePropertyChanged(param.PropName);
                }));
            });
        }

        public bool LogFilter(object sender)
        {
            if (sender == null)
            {
                return true;
            }
            var log = (LogMessage)sender;
            if (!String.IsNullOrEmpty(LogSearch))
            {
                if ((log.Date + log.Status + log.Source + log.subject).Contains(LogSearch))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private RelayCommand openLogCommand;
        public RelayCommand OpenLogCommand
        {
            get => openLogCommand ?? (openLogCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            if (File.Exists($@"Logs\Log {LogDate.ToString("dd-MM-yy")}.txt"))
                            {
                                Process.Start("notepad.exe", $@"Logs\Log {LogDate.ToString("dd-MM-yy")}.txt");
                            }
                        }
                        catch (Exception e)
                        {
                            NotificationService.AddtoLog("Exception", "Log", e.Message);
                        }
                        
                    }
                ));
        }

        private RelayCommand clearLogCommand;
        public RelayCommand ClearLogCommand
        {
            get => clearLogCommand ?? (clearLogCommand = new RelayCommand(
                    () =>
                    {                        
                        MainLog.Clear();
                        NotificationService.AddtoLog("Done","Log", "Log cleared");
                    }
                ));
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ?? (searchCommand = new RelayCommand(
                   () =>
                   {
                       MainLogView.Filter = LogFilter;
                       MainLogView.Refresh();
                   }
                ));
            }
        }
    }
}
