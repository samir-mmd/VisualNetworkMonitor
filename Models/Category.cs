using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Windows.Media.Imaging;

namespace VNM2020.Models
{
    public class Category : ObservableObject
    {
        public int CategoryId { get; set; }

        private string name;        
        public string Name { get => name; set => Set(ref name, value); }

        private string iconPath = "Default.jpg";
        public string IconPath { get => iconPath; set 
            { 
                Set(ref iconPath, value);
                RaisePropertyChanged("Icon");
            }
        }

        private double iconOpacity = 0.3;
        public double IconOpacity { get => iconOpacity; set => Set(ref iconOpacity, value); }

        private bool expanded;
        public bool Expanded { get => expanded; set { 
                
                Set(ref expanded, value);
                Core.Instance.UpdateCategory(this);
            } 
        }

        [NotMapped]
        public ObservableCollection<Host> hosts = new ObservableCollection<Host>();
        [NotMapped]
        public ObservableCollection<Host> Hosts { get => hosts; set => Set(ref hosts, value); }

        [NotMapped]
        public BitmapSource icon;
        [NotMapped]
        public BitmapSource Icon
        {
            get
            {
                try
                {
                    using (var stream = new FileStream($@"Icons/{IconPath}", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                }
                catch (Exception)
                {
                    using (var stream = new FileStream($@"Icons/Default.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                }

            }

            set => Set(ref icon, value);
        }

        [NotMapped]
        public ICollectionView HostsView { get; set; }

    }
}
