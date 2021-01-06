using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VNM2020.Messaging;
using VNM2020.Models;
using VNM2020.Navigation;
using VNM2020.Services;
using VNM2020.Views;

namespace VNM2020.ViewModels
{
    class FirstScreenViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;

        LogScreenWindow logScreenWindownew = new LogScreenWindow();
       
        public Visibility WaitingVisibility { get => Core.Instance.waitingVisibility; set => Set(ref Core.Instance.waitingVisibility, value); }

        public BitmapSource MapImage
        {
            get
            {
                using (var stream = new FileStream(@"Maps\" + GlobalSettings.Instance.picpath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }                
            }
            set => Set(ref Core.Instance.mapImage, value);
        }       

        public bool okbox = true;
        public bool holdbox = true;
        public bool pausebox = true;
        public bool errorbox = true;
        public bool Errorbox { get => errorbox; set => Set(ref errorbox, value); }
        public bool Holdbox { get => holdbox; set => Set(ref holdbox, value); }
        public bool Okbox { get => okbox; set => Set(ref okbox, value); }
        public bool Pausebox { get => pausebox; set => Set(ref pausebox, value); }
        
        public string TipBox { get => Core.Instance.tipBox; set => Set(ref Core.Instance.tipBox, value); }

        public string Search
        {
            get => Core.Instance.search;
            set
            {
                Set(ref Core.Instance.search, value);
            }
        }

        public double Mapzoom
        {
            get => GlobalSettings.Instance.mapzoom;
            set
            {
                Set(ref GlobalSettings.Instance.mapzoom, value);
            }
        }

        public double Mapopacity
        {
            get => GlobalSettings.Instance.mapopacity;
            set
            {
                Set(ref GlobalSettings.Instance.mapopacity, value);
            }
        }

        public Host Selected
        {
            get => Core.Instance.selected;
            set
            {
                if (Core.Instance.selected != null)
                {                    
                    Core.Instance.selected.Selection = false;                    
                }
                Set(ref Core.Instance.selected, value);
                if (Selected != null)
                {
                    Selected.Selection = true;                    
                }



            }
        }

        public Category selectedHostCategory;
        public Category SelectedHostCategory { get => selectedHostCategory; set => Set(ref selectedHostCategory, value); }

        public ObservableCollection<Host> AllHosts
        {
            get => Core.Instance.allHosts;
            set => Set(ref Core.Instance.allHosts, value);
        }

        public ObservableCollection<Category> Categories
        {
            get => Core.Instance.categories;
            set => Set(ref Core.Instance.categories, value);
        }

        public ICollectionView CategoryView { get; private set; }

        public FirstScreenViewModel(NavigationService navigationService)
        {            
            this.navigationService = navigationService;
            MessageRegister();            
            CategoryView = CollectionViewSource.GetDefaultView(Categories);
            CategoryView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));           
        }

        public bool HostFilter(object sender)
        {
            if (sender == null)
            {
                return true;
            }
            var host = (Host)sender;
            if (!String.IsNullOrEmpty(Core.Instance.search))
            {
                if ((host.Name + host.Address+host.Mac+host.Notes).Contains(Core.Instance.search))
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

        private void MessageRegister()
        {
            Messenger.Default.Register<MoveMessage>(this, param =>
            {
                
                if (Selected != null && param.Zoom == 0)
                {
                    if ((Selected.Colnumber + param.Col)< GlobalSettings.Instance.horizontalLimit && (Selected.Colnumber + param.Col)>0
                    && (Selected.Rownumber + param.Row) < GlobalSettings.Instance.verticalLimit && (Selected.Rownumber + param.Row) > 0)
                    {
                        Selected.Colnumber += param.Col;
                        Selected.Rownumber += param.Row;
                    }
                                   
                }
                else if (param.Zoom > 0)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        if (Selected != null)
                        {
                            Selected.Scale += 0.5;
                            Core.Instance.UpdateHost(Selected);                         
                        }
                        return;
                    }

                    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        if (Mapopacity < 1)
                        {
                            Mapopacity += 0.05;
                        }
                        return;
                    }
                    else
                    {                       
                        Mapzoom += 0.01;
                        return;
                    }

                }
                else if (param.Zoom < 0)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        if (Selected != null && Selected.Scale > 0.1)
                        {
                            Selected.Scale -= 0.5;
                            Core.Instance.UpdateHost(Selected);
                        }
                            return;
                    }
                    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        if (Mapopacity > 0)
                        {
                            Mapopacity -= 0.05;
                        }
                            return;
                    }
                    else if (Mapzoom > 0.02)
                    {
                        Mapzoom -= 0.01;
                        return;
                    }
                }
            });

            Messenger.Default.Register<UIMessage>(this, param =>
            {
                if (param.PropName!= "MainLogView")
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        RaisePropertyChanged(param.PropName);
                    }));
                }                
            });

            Messenger.Default.Register<BlockingMessage>(this, param =>
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    Application.Current.Windows[1].IsEnabled = param.MainWindowEnabled;
                    if (param.MainWindowEnabled)
                    {                       
                        if (param.Context.Contains("AddCategory"))
                        {
                            CategoryView.Refresh();
                        }
                        if (param.Context.Contains("EditCategory")&& Core.Instance.targetCategory!=null)
                        {
                            Core.Instance.UpdateCategory(Core.Instance.targetCategory);
                        }
                        if (param.Context.Contains("Settings"))
                        {
                            Core.Instance.UpdateSettings();
                        }
                        
                    }
                }));
            });

            Messenger.Default.Register<NavigationMessage>(this, param =>
            {
                navigationService.GoTo(param.Name);
            });
        }

        private RelayCommand<Host> selectfrommap;
        public RelayCommand<Host> Selectfrommap
        {
            get => selectfrommap ?? (selectfrommap = new RelayCommand<Host>(
                   async param =>
                    {                      
                       
                        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                        {
                            if (Selected != null)
                            {
                                Selected.Father = param;
                                Core.Instance.UpdateHost(Selected);
                            }
                        }
                        else if (Selected != param)
                        {
                            if (GlobalSettings.Instance.horizontalLimit + GlobalSettings.Instance.verticalLimit ==0)
                            {
                                GlobalSettings.Instance.SetMapLimits();
                            }
                            Selected = param;                          
                            TipBox = "Loading";
                            SelectedHostCategory = null;                           
                            await Task.Run(() =>
                            {
                                Core.Instance.GetActions(Selected);
                            });
                            TipBox = "";                            
                        }
                    }
                ));
        }

        private RelayCommand<TreeView> mainTreeSelectionCommand;
        public RelayCommand<TreeView> MainTreeSelectionCommand
        {
            get => mainTreeSelectionCommand ?? (mainTreeSelectionCommand = new RelayCommand<TreeView>(
                   async param =>
                    {
                        
                        if (param.SelectedItem != null && param.SelectedItem.ToString().Contains("Host"))
                        {
                            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                            {
                                if (param.SelectedItem as Host != null && Selected!=null)
                                {
                                    Selected.Father = param.SelectedItem as Host;
                                    Core.Instance.UpdateHost(Selected);                                    
                                }
                            }

                            Selected = param.SelectedItem as Host;
                            TipBox = "Loading";
                            SelectedHostCategory = null;
                            await Task.Run(() =>
                            {
                                Core.Instance.GetActions(Selected);
                            });
                            TipBox = "";

                        }
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
                        foreach (var item in Categories)
                        {
                            item.HostsView.Filter = HostFilter;
                            item.HostsView.Refresh();
                        }                       
                    }
                ));
            }
        }

        private RelayCommand<Category> addHostDialogCommand;
        public RelayCommand<Category> AddHostDialogCommand
        {
            get
            {
                return addHostDialogCommand ?? (addHostDialogCommand = new RelayCommand<Category>(
                    param =>
                    {
                        Core.Instance.targetCategory = param;
                        var window = new DialogWindow
                        {
                            Title = "Add New Host",
                            DataContext = new DialogViewModel()
                        };
                        navigationService.GoTo("AddHost");
                        window.Show();                       
                    }
                ));
            }
        }

        private RelayCommand addCategoryDialogCommand;
        public RelayCommand AddCategoryDialogCommand
        {
            get
            {
                return addCategoryDialogCommand ?? (addCategoryDialogCommand = new RelayCommand(
                    () =>
                    {
                        var window = new DialogWindow();
                        window.Title = "Add New Category";
                        window.DataContext = new DialogViewModel();
                        navigationService.GoTo("AddCategory");
                        window.Show();
                    }
                ));
            }
        }

        private RelayCommand resetFatherCommand;
        public RelayCommand ResetFatherCommand
        {
            get
            {
                return resetFatherCommand ?? (resetFatherCommand = new RelayCommand(
                   () =>
                    {
                        Selected.Father = Selected;
                        Core.Instance.UpdateHost(Selected);
                    }
                    ,
                   ()=>Selected!=null && Selected.Father!=Selected
                ));
            }
        }

        private RelayCommand<string> showTipCommand;
        public RelayCommand<string> ShowTipCommand
        {
            get
            {
                return showTipCommand ?? (showTipCommand = new RelayCommand<string>(
                    param =>
                    {
                      TipBox=param;                     
                    }
                ));
            }
        }

        private RelayCommand clearTipCommand;
        public RelayCommand ClearTipCommand
        {
            get
            {
                return clearTipCommand ?? (clearTipCommand = new RelayCommand(
                    () =>
                    {
                        TipBox = "";
                    }
                ));
            }
        }

        private RelayCommand setCategoryCommand;
        public RelayCommand SetCategoryCommand
        {
            get
            {
                return setCategoryCommand ?? (setCategoryCommand = new RelayCommand(
                    () =>
                    {
                        Selected.CategoryId = SelectedHostCategory.CategoryId;
                        Core.Instance.UpdateHost(Selected);
                        var TempHost = Selected;
                        var TempCat = Categories.Where(i => i.Hosts.Contains(Selected)).First();
                        TempCat.Hosts.Remove(Selected);
                        SelectedHostCategory.Hosts.Add(Selected);
                        SelectedHostCategory = null;
                    }
                    ,
                    ()=>Selected!=null && SelectedHostCategory!=null && Selected.CategoryId!=SelectedHostCategory.CategoryId
                ));
            }
        }

        private RelayCommand removeHostCommand;
        public RelayCommand RemoveHostCommand
        {
            get
            {
                return removeHostCommand ?? (removeHostCommand = new RelayCommand(
                   async () =>
                    {
                        MessageBoxResult result = MessageBox.Show($"Remove {Selected.Name}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        
                        if (result == MessageBoxResult.Yes)
                        {
                            var TempCat = Categories.Where(i => i.Hosts.Contains(Selected)).First();
                            Core.Instance.allHosts.Remove(Selected);
                            TempCat.Hosts.Remove(Selected);
                            var childrens = AllHosts.Where(f => f.Father == Core.Instance.selected).ToList();
                            foreach (var item in childrens)
                            {
                                item.Father = item;
                                Core.Instance.UpdateHost(item);
                            }

                            await Task.Run(() => {
                                Core.Instance.RemoveHost(Selected);
                            }); 
                            
                            Selected = null;
                        }
                    }
                    ,
                    () => Selected != null
                ));
            }
        }

        private RelayCommand<Category> editCategoryCommand;
        public RelayCommand<Category> EditCategoryCommand
        {
            get
            {
                return editCategoryCommand ?? (editCategoryCommand = new RelayCommand<Category>(
                    param =>
                    {
                        Core.Instance.targetCategory = param;
                        var window = new DialogWindow
                        {
                            Title = "Edit Category",
                            DataContext = new DialogViewModel()
                        };
                        navigationService.GoTo("EditCategory");
                        window.Show();                        
                    }
                ));
            }
        }

        private RelayCommand getHostDNSNameCommand;
        public RelayCommand GetHostDNSNameCommand
        {
            get
            {
                return getHostDNSNameCommand ?? (getHostDNSNameCommand = new RelayCommand(
                   async () =>
                   {
                      await Selected.GetNameOverIp();
                   }
                    ,
                    () => Selected != null
                ));
            }
        }

        private RelayCommand resetPositionCommand;
        public RelayCommand ResetPositionCommand
        {
            get
            {
                return resetPositionCommand ?? (resetPositionCommand = new RelayCommand(
                   () =>
                   {
                       Selected.Rownumber = 0;
                       Selected.Colnumber = 0;
                       Core.Instance.UpdateHost(Selected);
                   }
                   ,
                   ()=>Selected!=null
                ));
            }
        }

        private RelayCommand pingHostCommand;
        public RelayCommand PingHostCommand
        {
            get
            {
                return pingHostCommand ?? (pingHostCommand = new RelayCommand(
                   () =>
                   {
                       Selected.Tick(true);                       
                       Core.Instance.UpdateHost(Selected);
                   }
                   ,
                   () => Selected != null
                ));
            }
        }

        private RelayCommand openSettingsCommand;
        public RelayCommand OpenSettingsCommand
        {
            get
            {
                return openSettingsCommand ?? (openSettingsCommand = new RelayCommand(
                    () =>
                    {
                        var window = new DialogWindow
                        {
                            Title = "Settings",
                            DataContext = new DialogViewModel()
                        };
                        navigationService.GoTo("Settings");
                        window.Show(); 
                    }
                ));
            }
        }

        private RelayCommand openLogWindowCommand;
        public RelayCommand OpenLogWindowCommand
        {
            get
            {
                return openLogWindowCommand ?? (openLogWindowCommand = new RelayCommand(
                    () =>
                    {
                        if (!logScreenWindownew.IsActive)
                        {
                            logScreenWindownew.DataContext = new LogScreenWindowViewModel();
                            navigationService.GoTo("LogScreen");
                            logScreenWindownew.Show();
                        }                                           
                    }
                ));
            }
        }

       
    }
}
