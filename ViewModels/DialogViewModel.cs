using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace VNM2020.ViewModels
{
    class DialogViewModel : ViewModelBase
    {
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage { get => currentPage; set => Set(ref currentPage, value); }

        public DialogViewModel()
        {
            Messenger.Default.Register<ViewModelBase>(this, param =>
            {
                if (!param.ToString().Contains("FirstScreenViewModel")&&!param.ToString().Contains("LogScreen"))
                {
                    CurrentPage = param;
                }
            });
        }
    }
}
