using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VNM2020.Models;
using VNM2020.Navigation;

namespace VNM2020.ViewModels
{
    class AddHostViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly NavigationService navigationService;

        #region IPrange
        public bool Scan = false;
        private string rangeinfo;
        public string Rangeinfo { get => rangeinfo; set => Set(ref rangeinfo, value); }

        private double rangeprogress;
        public double Rangeprogress { get => rangeprogress; set => Set(ref rangeprogress, value); }

        public ObservableCollection<Host> rangehosts = new ObservableCollection<Host>();
        public ObservableCollection<Host> Rangehosts
        {
            get => rangehosts;
            set => Set(ref rangehosts, value);
        }

        public System.Collections.IList SelectedItems
        {
            get
            {
                return Selectedrange;
            }
            set
            {
                Selectedrange.Clear();
                foreach (Host model in value)
                {
                    Selectedrange.Add(model);
                }
            }
        }

        public ObservableCollection<Host> selectedrange = new ObservableCollection<Host>();
        public ObservableCollection<Host> Selectedrange
        {
            get => selectedrange;
            set => Set(ref selectedrange, value);
        }

        private int s1 = 192;
        public int S1 { get => s1; set => Set(ref s1, value); }

        private int s2 = 168;
        public int S2 { get => s2; set => Set(ref s2, value); }

        private int s3 = 0;
        public int S3 { get => s3; set => Set(ref s3, value); }

        private int s4 = 1;
        public int S4 { get => s4; set => Set(ref s4, value); }

        private int f1 = 192;
        public int F1 { get => f1; set => Set(ref f1, value); }

        private int f2 = 168;
        public int F2 { get => f2; set => Set(ref f2, value); }

        private int f3 = 0;
        public int F3 { get => f3; set => Set(ref f3, value); }

        private int f4 = 10;
        public int F4 { get => f4; set => Set(ref f4, value); }

        public bool ValidIp = false;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "S1":
                        if (S1 < 0 || S1 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;

                    case "S2":
                        if (S2 < 0 || S2 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "S3":
                        if (S3 < 0 || S3 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "S4":
                        if (S4 < 0 || S4 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "F1":
                        if (F1 < 0 || F1 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "F2":
                        if (F2 < 0 || F2 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "F3":
                        if (F3 < 0 || F3 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;
                    case "F4":
                        if (F4 < 0 || F4 > 255)
                        {
                            IpValidationCheck();
                            error = "Enter Valid Ip Address";
                        }
                        else
                        {
                            IpValidationCheck();
                        }
                        break;

                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public Category TargetCategory {get => Core.Instance.targetCategory; set => Set(ref Core.Instance.targetCategory, value);}

        private Host targetHost = new Host();
        public Host TargetHost { get => targetHost; set => Set(ref targetHost, value); }

        public ObservableCollection<Category> Categories
        {
            get => Core.Instance.categories;
            set => Set(ref Core.Instance.categories, value);
        }

        public AddHostViewModel(NavigationService navigationService)
        {            
            this.navigationService = navigationService;              
        }

        public void IpValidationCheck()
        {           
            ValidIp = false;
            if (S1 <= F1 && S2 <= F2 && S3 <= F3 && S4 <= F4)
            {
                ValidIp = true;
            }
        }

        void Rangeengine()
        {            
            for (int i = 0; i < Rangehosts.Count; i++)
            {
                Rangeprogress = i / (Convert.ToDouble(Rangehosts.Count) / 100);
                Rangeinfo = $"{Rangeprogress.ToString("f2")}%";
                if (Scan)
                {
                    if (Rangehosts[i].Status == "New")
                    {
                        Rangehosts[i].RangeTick();
                    }
                }
            }


            App.Current.Dispatcher.BeginInvoke((System.Action)delegate ()
            {
                for (int i = 0; i < Rangehosts.Count; i++)
                {
                    if (Rangehosts[i].Status == "Error")
                    {
                        Rangehosts.Remove(Rangehosts[i]);
                        i--;
                    }
                }
                Rangeprogress = 100;
                Rangeinfo = "Scan is Done";
                Scan = false;
            });

        }

        private RelayCommand<Window> addHostCommand;
        public RelayCommand<Window> AddHostCommand
        {
            get
            {
                return addHostCommand ?? (addHostCommand = new RelayCommand<Window>(
                    param=>
                    {
                        TargetHost.Scale = 5;                      
                        Core.Instance.AddHost(TargetHost, TargetCategory.CategoryId);
                        TargetHost = new Host();                        
                    }
                    ,
                    param=>TargetCategory!=null && Core.Instance.categories.Contains(TargetCategory)
                ));
            }
        }

        private RelayCommand<Window> addRangeCommand;
        public RelayCommand<Window> AddRangeCommand
        {
            get
            {
                return addRangeCommand ?? (addRangeCommand = new RelayCommand<Window>(
                    param =>
                    {
                        List<Host> tempList = new List<Host>();
                        foreach (var item in Selectedrange)
                        {
                            item.Scale = 5;
                            item.Seconds = TargetHost.Seconds;
                            item.CategoryId = TargetCategory.CategoryId;                          
                            tempList.Add(item);
                        }                            
                        Core.Instance.AddRange(Selectedrange);
                        Selectedrange.Clear();

                        foreach (var item in tempList)
                        {                           
                            Rangehosts.Remove(item);
                        }

                    }
                    ,
                    param => TargetCategory != null && Core.Instance.categories.Contains(TargetCategory) && Selectedrange.Count>0
                ));
            }
        }

        private RelayCommand scanRangeCommand;
        public RelayCommand ScanRangeCommand
        {
            get
            {
                return scanRangeCommand ?? (scanRangeCommand = new RelayCommand(
                    () =>
                    {                        
                        Scan = true;
                        Rangehosts.Clear();
                        int dmax = 255;
                        for (int a = S1; a <= F1; a++)
                        {
                            for (int b = S2; b <= F2; b++)
                            {
                                for (int c = S3; c <= F3; c++)
                                {
                                    for (int d = S4; d <= dmax; d++)
                                    {
                                        if (c == F3)
                                        {
                                            dmax = F4;
                                        }
                                        string Address = $"{a}.{b}.{c}.{d}";                                       
                                        if (!Core.Instance.allHosts.Any(a => a.Address == Address))
                                        {
                                            Host newhost = new Host();
                                            newhost.Name = "Unknown Host";
                                            newhost.Address = Address;
                                            newhost.Status = "New";
                                            Rangehosts.Add(newhost);
                                        }
                                    }
                                }
                            }
                        }
                        new Task(Rangeengine).Start();
                    }
                     ,
                    () => ValidIp && !Scan
                ));
            }
        }

        private RelayCommand stopScanCommand;
        public RelayCommand StopScanCommand
        {
            get
            {
                return stopScanCommand ?? (stopScanCommand = new RelayCommand(
                    () =>
                    {                        
                        Scan = false;                       
                    }
                     ,
                    () => Scan
                ));
            }
        }


    }
}
