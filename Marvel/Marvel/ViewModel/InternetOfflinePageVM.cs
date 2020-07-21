using Marvel.Helpers;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marvel.ViewModel
{
    class InternetOfflinePageVM: BaseVM
    {
        public InternetOfflinePageVM()
        {
            InternetMessageOffLine = TranslateExtension.TranslateText("InternetMessageOffLine");
            ClosePopUpCommand = new Command(async () => await ExecuteClosePopUpCommand());
    
        }

        public Command ClosePopUpCommand { get; }

        private string _internetMessageOffLine;
        public string InternetMessageOffLine
        {
            get { return _internetMessageOffLine; }
            set
            {
                if (_internetMessageOffLine != value)
                {
                    _internetMessageOffLine = value;
                    OnPropertyChanged("InternetMessageOffLine");
                }
            }
        }

        private async Task ExecuteClosePopUpCommand()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}
