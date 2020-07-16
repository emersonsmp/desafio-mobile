using Marvel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Marvel.ViewModel;

namespace Marvel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoreInfoView : ContentPage
    {
        public List<Result> collection;

        public MoreInfoView(Result character)
        {
            InitializeComponent();
            BindingContext =  new MoreInfoVM(character);
        }

        private async void OnImageTapped(Object sender, EventArgs e)
        {
            var imagePreview = new HeroFullScreen((sender as Image).Source);

            await Navigation.PushModalAsync(new NavigationPage(imagePreview));
        }
    }
}