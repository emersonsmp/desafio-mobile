using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Marvel.Model;
using Marvel.Service;
using Xamarin.Forms;
using Marvel.View;
using System.Linq;

namespace Marvel.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private string _searchText;
        public string searchText
        {
            get { return _searchText; }
            set { if (_searchText != value) { _searchText = value; OnPropertyChanged("searchText"); } }
        }

        readonly IMarvelDataService _dataService;
        public bool IsBusy { get; set; }
        Characters characters { get; set; }

        public ObservableCollection<Result> Lista { get; set; }

        public ObservableCollection<Result> _ListaDeHeroes { get; set; }
        public ObservableCollection<Result> ListaDeHeroes
        {
            get { return _ListaDeHeroes; }
            set
            {
                _ListaDeHeroes = value; OnPropertyChanged("ProdutosAtivosDoMercado");
            }
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

        public MainPageVM()
        {
            Lista = new ObservableCollection<Result>();
            ListaDeHeroes = new ObservableCollection<Result>();
            var hashService = DependencyService.Get<IHashService>();
            _dataService = new MarvelDataService(hashService);

            Task.Run(LoadComics);
        }

        public Command MoreCharacterInfoComand => new Command<object>((object obj) =>
        {
            Result character = obj as Result;
            App.Current.MainPage.Navigation.PushModalAsync(new MoreInfoView(character));

        });

        #region METODO DE BUSCA
        public Command SearchCommand => new Command<string>((text) =>
        {
            if (text.Length >= 3)
            {
                ListaDeHeroes.Clear();
                var suggestions = Lista.Where(c => c.name.ToLower().StartsWith(text.ToLower())).ToList();

                foreach (var recipe in suggestions)
                    ListaDeHeroes.Add(recipe);

                if (suggestions.Count == 0)
                {
                    HerosListIsNull = true;
                    ListViewIsVisible = false;
                }
            }
            else
            {
                ListaDeHeroes.Clear();
                for (int i = 0; i < Lista.Count; i++)
                {
                    ListaDeHeroes.Add(Lista[i]);
                }

                HerosListIsNull = false;
                ListViewIsVisible = true;
            }

        });
        #endregion

        async Task LoadComics()
        {
            //Characters characters;

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                characters = await _dataService.GetCharacters();

                //List<Result>Lista = new List<Result>((IEnumerable<Result>)characters.data.results);
                Lista = new ObservableCollection<Result>((IEnumerable<Result>)characters.data.results);

                for (int i = 0; i < Lista.Count; i++)
                {
                    ListaDeHeroes.Add(Lista[i]);
                }

                ListViewIsVisible = true;
                HerosListIsNull = false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
