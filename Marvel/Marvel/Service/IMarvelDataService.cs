using Marvel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Service
{
    public interface IMarvelDataService
    {
        Task<Characters> GetCharacters(string orderBy = null);
        //Task<Characters> GetCharacter(int id);
        //Characters GetHeroes(string orderBy = null);

    }
}
