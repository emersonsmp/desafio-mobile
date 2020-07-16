using Marvel.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Service
{
    public class MarvelDataService : IMarvelDataService
    {
        const string _API_PRIVATE_KEY = "4ec1042eaac4551902ef41b36100141d82400ffd";
        const string _API_PUBLIC_KEY  = "cc0bf97cd028a24ef963842e9ad86f41";

        readonly IHashService _hashService;

        public MarvelDataService(IHashService hashService)
        {
            _hashService = hashService;
        }

        //public async Task<IEnumerable<Characters>> GetCharacters(string orderBy = null)
        public async Task<Characters> GetCharacters(string orderBy = null)
        {
            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);

            if (string.IsNullOrWhiteSpace(orderBy))
                orderBy = "issueNumber";

            var url = $@"https://gateway.marvel.com/v1/public/characters?apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";

            var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var responseObject = JObject.Parse(response);

            //return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Characters>>(responseObject["data"]["results"].ToString()));
            var resposta = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Characters>(responseObject.ToString()));
            return resposta;
        }

        /*public Characters GetHeroes(string orderBy = null)
        {
            int seriesId = 2029;
            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);

            if (string.IsNullOrWhiteSpace(orderBy))
                orderBy = "issueNumber";

            var url =$@"https://gateway.marvel.com/v1/public/characters?apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";

            //var url = $@"http://gateway.marvel.com/v1/public/series/{seriesId}/comics?orderBy={orderBy}&apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";

            var client = new HttpClient();
            var response = client.GetStringAsync(url).GetAwaiter().GetResult();

            var responseObject = JObject.Parse(response);

            //return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Characters>>(responseObject["data"]["results"].ToString()));
            var resposta = JsonConvert.DeserializeObject<Characters>(responseObject.ToString());
            return resposta;

        }*/
    }
}
