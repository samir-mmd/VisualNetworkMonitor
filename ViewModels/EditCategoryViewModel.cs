using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VNM2020.Models;
using VNM2020.Navigation;

namespace VNM2020.ViewModels
{
    class EditCategoryViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;

        public Category TargetCategory { get => Core.Instance.targetCategory; set => Set(ref Core.Instance.targetCategory, value); }

        ObservableCollection<string> iconList = new ObservableCollection<string>();
        public ObservableCollection<string> IconList { get => iconList; set => Set(ref iconList, value); }

        public EditCategoryViewModel(NavigationService navigationService)
        {            
            this.navigationService = navigationService;
            var tempList = Directory.GetFiles(@"Icons\","*.jpg").Select(Path.GetFileName).ToArray();
            foreach (var item in tempList)
            {
                IconList.Add(item);
            }
        }


        private RelayCommand<Window> removeCategoryCommand;
        public RelayCommand<Window> RemoveCategoryCommand
        {
            get
            {
                return removeCategoryCommand ?? (removeCategoryCommand = new RelayCommand<Window>(
                   async param =>
                    {
                        MessageBoxResult result = MessageBox.Show($"Remove {TargetCategory.Name}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            param.Close();
                            Core.Instance.categories.Remove(TargetCategory);
                            for (int i = 0; i < TargetCategory.Hosts.Count; i++)
                            {
                                var childrens = Core.Instance.allHosts.Where(f => f.Father == TargetCategory.Hosts[i]).ToList();
                                foreach (var item in childrens)
                                {
                                    item.Father = item;
                                    Core.Instance.UpdateHost(item);
                                }
                                Core.Instance.allHosts.Remove(TargetCategory.Hosts[i]);
                            }
                            await Task.Run(() =>
                            {
                                Core.Instance.RemoveCategory(TargetCategory);
                                TargetCategory = null;
                            });
                        }
                        
                    }                    
                ));
            }
        }


    }
}
