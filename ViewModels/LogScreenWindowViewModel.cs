using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace VNM2020.ViewModels
{
    class LogScreenWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage { get => currentPage; set => Set(ref currentPage, value); }

        public LogScreenWindowViewModel()
        {
            Messenger.Default.Register<ViewModelBase>(this, param =>
            {
                if (param.ToString().Contains("LogScreen"))
                {   
                    CurrentPage = param;
                }
            });
        }

    }
}
