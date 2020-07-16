using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {         
            base.OnAppearing();

            int count = 0, repeticoes = 4;

            while (count < repeticoes)
            {
                await SplashImage.ScaleTo(1.0, 300);
                await SplashImage.ScaleTo(0.5, 200);
                count++;
            }
            await SplashImage.ScaleTo(1.0, 200);

            Application.Current.MainPage = new NavigationPage(new MainPageView()) { BarBackgroundColor = Color.DarkRed, BarTextColor = Color.White };
        }
    }
}