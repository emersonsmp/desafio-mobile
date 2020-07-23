using Marvel.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Marvel.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        public INavigation Navigation;
        public BaseVM(INavigation navigation = null)
        {
            Navigation = navigation;
        }
        public static bool InternetConnectivity()
        {
            var connectivity = Connectivity.NetworkAccess;
            if (connectivity == NetworkAccess.Internet)
                return true;

            return false;
        }

        private bool _NoConnection;
        public bool NoConnection { 
            get { return _NoConnection; }
            set
            {
                if (_NoConnection != value)
                {
                    _NoConnection = value;
                    OnPropertyChanged("NoConnection");
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            { 
                if (_title != value) { 
                    _title = value; 
                    OnPropertyChanged("Title"); 
                } 
            }
        }

        private bool _isBusy;
        public  bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        private string _searchText;
        public string searchText
        {
            get { return _searchText; }
            set { if (_searchText != value) { _searchText = value; OnPropertyChanged("searchText"); } }
        }

        public bool _HerosListIsNull { get; set; }
        public bool HerosListIsNull
        {
            get { return _HerosListIsNull; }
            set
            {
                _HerosListIsNull = value; OnPropertyChanged("HerosListIsNull");
            }
        }

        public bool _ListViewIsVisible { get; set; }
        public bool ListViewIsVisible
        {
            get { return _ListViewIsVisible; }
            set
            {
                _ListViewIsVisible = value; OnPropertyChanged("ListViewIsVisible");
            }
        }

        public ObservableCollection<Result> _ListaDeHeroes { get; set; }
        public ObservableCollection<Result> ListaDeHeroes
        {
            get { return _ListaDeHeroes; }
            set
            {
                _ListaDeHeroes = value; OnPropertyChanged("ListaDeHeroes");
            }
        }

        public virtual void OnDisappearing() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }

    }
}
