using Marvel.Model;
using Marvel.Service;
using Marvel.ViewModel;
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
    public partial class MainPageView : ContentPage
    {
        MainPageVM viewmodel;
        public MainPageView()
        {
            InitializeComponent();

            var hashService = DependencyService.Get<IHashService>();
            MarvelDataService _dataService = new MarvelDataService(hashService);

            BindingContext = viewmodel = new MainPageVM(_dataService);
        }

        protected override async void OnAppearing()
        {
        }

        protected  override  void  OnDisappearing()
        {
        }
    }
}