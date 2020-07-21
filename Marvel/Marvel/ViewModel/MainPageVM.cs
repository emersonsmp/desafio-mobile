using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Marvel.Model;
using Marvel.Service;
using Xamarin.Forms;
using Xamarin.Essentials;
using Marvel.View;
using System.Linq;
using Rg.Plugins.Popup.Extensions;

namespace Marvel.ViewModel
{
    public class MainPageVM : BaseVM
    {

        readonly IMarvelDataService _dataService;
        Characters characters { get; set; }
        public ObservableCollection<Result> Lista { get; set; }
        public Command RefreshListOfHerosCommand  { get; set; }


        public MainPageVM(MarvelDataService dataservice)
        {

            /*if (!InternetConnectivity())
                Navigation.PushPopupAsync(new InternetOfflinePage());*/

            _dataService = dataservice;
            Lista = new ObservableCollection<Result>();
            ListaDeHeroes = new ObservableCollection<Result>();
            RefreshListOfHerosCommand = new Command(RefreshListOfHerosExecute);
            Task.Run(LoadComics);
        }


        public Command MoreCharacterInfoComand => new Command<object>((object obj) =>
        {
            Result character = obj as Result;
            App.Current.MainPage.Navigation.PushModalAsync(new MoreInfoView(character));

        });

        public Command SearchCommand => new Command<string>((text) =>
        {
            ListaDeHeroes.Clear();
            var CharactersFound = Lista.Where(c => c.name.ToLower().StartsWith(text.ToLower())).ToList();

            if (CharactersFound.Count == 0)
            {
                HerosListIsNull = true;
                ListViewIsVisible = false;
            }
            else
            {
                HerosListIsNull = false;
                ListViewIsVisible = true;

                foreach (var recipe in CharactersFound)
                    ListaDeHeroes.Add(recipe);
            }

        });

        async Task LoadComics()
        {

            if (IsBusy) return;

            IsBusy = true;

            try
            {
                if (InternetConnectivity()) {
                    characters = await _dataService.GetCharacters();
                    Lista = new ObservableCollection<Result>((IEnumerable<Result>)characters.data.results);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeHeroes.Add(Lista[i]);
                    }

                    ListViewIsVisible = true ;
                    HerosListIsNull   = false;
                }
                else
                {
                    //NoConnection = true;
                    //await App.Current.MainPage.DisplayAlert("Atenção", "Verifique sua conexão", "OK");
                    await Navigation.PushPopupAsync(new InternetOfflinePage());
                }
                
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void RefreshListOfHerosExecute()
        {

        }
    }
}
