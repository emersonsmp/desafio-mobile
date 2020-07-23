using Marvel.Helpers;
using Marvel.Resources;
using Plugin.Multilingual;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Marvel.ViewModel
{
    class ChangeLanguageVM: BaseVM
    {
        private string _LanguageSelection;
        public string  LanguageSelection {

            get { return _LanguageSelection; }
            set {
              if (_LanguageSelection != value)
              {
                 _LanguageSelection = value;
                 OnPropertyChanged("LanguageSelection");
              }
            }
        }

        public string _ThemeSelection;
        public string ThemeSelection
        {
            get { return _ThemeSelection; }
            set
            {
                if (_ThemeSelection != value)
                {
                    _ThemeSelection = value;
                    OnPropertyChanged("ThemeSelection");
                }
            }
        }

        private bool _IsVisibleCheckFlagBR;
        public bool IsVisibleCheckFlagBR
        {
            get { return _IsVisibleCheckFlagBR; }
            set { 
                if(_IsVisibleCheckFlagBR != value) 
                { 
                    _IsVisibleCheckFlagBR = value;
                   OnPropertyChanged("IsVisibleCheckFlagBR");
                } 
            }
        }

        private bool _IsVisibleCheckFlagUSA;
        public  bool IsVisibleCheckFlagUSA
        {
            get { return _IsVisibleCheckFlagUSA; }
            set
            {
                if (_IsVisibleCheckFlagUSA != value)
                {
                    _IsVisibleCheckFlagUSA = value;
                    OnPropertyChanged("IsVisibleCheckFlagUSA");
                }
            }
        }

        public Command ChangeLanguageCommand { get; }
        public Command ClosePopUpCommand { get; }

        public ChangeLanguageVM()
        {
            LanguageSelection = TranslateExtension.TranslateText("SelectionLanguage");
            ThemeSelection = TranslateExtension.TranslateText("ThemeSelection");
            ChangeLanguageCommand = new Command<string>(async (args) => await ExecuteChangeLanguageCommand(args));
            ClosePopUpCommand = new Command(async () => await ExecuteClosePopUpCommand());
            SetCheckFlag();
        }

        void SetCheckFlag()
        {
            IsVisibleCheckFlagBR = App.AppCultureInfo.Equals("pt");
            IsVisibleCheckFlagUSA = !IsVisibleCheckFlagBR;
        }

        private async Task ExecuteChangeLanguageCommand(string language)
        {
            App.AppCultureInfo = language;
            Preferences.Set("appLanguage", language);
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(language);
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            MessagingCenter.Send(this, "changeLanguage");
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async Task ExecuteChangeAppThemeCommand()
        {
            //Preferences.Set("appDarkTheme", AppDarkTheme);
            //MessagingCenter.Send(this, "changeAppTheme", AppDarkTheme);
            //await PopupNavigation.Instance.PopAsync(true);
        }

        private async Task ExecuteClosePopUpCommand()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}
