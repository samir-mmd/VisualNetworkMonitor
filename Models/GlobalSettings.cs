using GalaSoft.MvvmLight;
using MahApps.Metro.Controls;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;
using System.Windows.Controls;

namespace VNM2020.Models
{
    public class GlobalSettings : ObservableObject
    {
        public static GlobalSettings instance = null;
        [NotMapped]
        public static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalSettings();
                }
                return instance;
            }
        }

        public int GlobalSettingsId { get; set; }

        public double mapzoom = 0.5;
        public double Mapzoom { get => mapzoom; set => Set(ref mapzoom, value); }

        public double mapopacity = 1;
        public double Mapopacity { get => mapopacity; set => Set(ref mapopacity, value); }
      
        public string picpath = "Default.png";
        public string Picpath { get => picpath; set => Set(ref picpath, value); }
      
        public string mailFrom = "";
        public string MailFrom { get => mailFrom; set => Set(ref mailFrom, value); }

        public string mailPass = "";
        public string MailPass { get => mailPass; set => Set(ref mailPass, value); }

        public string mailTo = "";
        public string MailTo { get => mailTo; set => Set(ref mailTo, value); }

        public int mailPort = 587;
        public int MailPort { get => mailPort; set => Set(ref mailPort, value); }

        public string mailServer = "";
        public string MailServer { get => mailServer; set => Set(ref mailServer, value); }

        public bool enableSSL = true;
        public bool EnableSSL { get => enableSSL; set => Set(ref enableSSL, value); }

        public bool enableNotifications = true;
        public bool EnableNotifications { get => enableNotifications; set => Set(ref enableNotifications, value); }

        public bool enableLog = true;
        public bool EnableLog { get => enableLog; set => Set(ref enableLog, value); }

        public bool shuffleOnStartUp = true;
        public bool ShuffleOnStartUp { get => shuffleOnStartUp; set => Set(ref shuffleOnStartUp, value); }

        public bool clearOnQuit = true;
        public bool ClearOnQuit { get => clearOnQuit; set => Set(ref clearOnQuit, value); }

        [NotMapped]
        public double verticalLimit = 0;
        [NotMapped]
        public double horizontalLimit = 0;

        [NotMapped]
        public bool Closing = false;

        public void SetMapLimits()
        {
            var mainmap = Application.Current.Windows[1].FindChild<Image>("MainMap");
            GlobalSettings.Instance.horizontalLimit = mainmap.ActualWidth - 10;
            GlobalSettings.Instance.verticalLimit = mainmap.ActualHeight - 10;
        }

    }
}
