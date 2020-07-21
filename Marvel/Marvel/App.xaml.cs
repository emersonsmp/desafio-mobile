using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Marvel.View;
using Xamarin.Essentials;
using Marvel.Resources;
using System.Globalization;
using Plugin.Multilingual;

namespace Marvel
{
    public partial class App : Application
    {
        public static string AppCultureInfo;
        public App()
        {
            InitializeComponent();

            AppCultureInfo = Preferences.Get("appLanguage", "en");
            AppResources.Culture = new CultureInfo(AppCultureInfo);
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(AppCultureInfo);
            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
