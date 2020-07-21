using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Marvel.ViewModel;

namespace Marvel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InternetOfflinePage : PopupPage
    {
        public InternetOfflinePage()
        {
            InitializeComponent();
            BindingContext = new InternetOfflinePageVM();
        }
    }
}