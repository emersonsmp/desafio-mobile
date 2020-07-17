using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Marvel.Model;

namespace Marvel.ViewModel
{
    public class MoreInfoVM
    {
        public Result _character { get; set; }
        public bool IsBusy { get; set; }
        public ObservableCollection<Item> ComicsList { get; set; }

        public MoreInfoVM(Result Character)
        {

            if (Character.description == "")
               Character.description = "Sem Descrição";

            _character = Character;
            ComicsList = new ObservableCollection<Item>();
            LoadCharacter();
        }

        private void LoadCharacter()
            {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ObservableCollection<Item> Lista = new ObservableCollection<Item>((IEnumerable<Item>)_character.comics.items);

                for (int i = 0; i < Lista.Count; i++)
                {
                    ComicsList.Add(Lista[i]);
                }

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
