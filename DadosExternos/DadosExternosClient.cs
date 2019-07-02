using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LojaDiscosAPI.Util;

namespace LojaDiscosAPI.DadosExternos
{

    public interface IDadosExternosClient
    {
        Task<string> GetDataAsync(string tag);
    }

    public class DadosExternosClient : IDadosExternosClient
    {
        private readonly HttpClient _client;

        public DadosExternosClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://ws.audioscrobbler.com/2.0/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = httpClient;
        }

        public async Task<string> GetDataAsync(string tag)
        {
            string APICode = ConfigurationManager.AppSetting["Lastfm_ApiKey"];
            return await _client.GetStringAsync("?method=tag.gettopalbums&format=json&api_key="+ APICode + "&tag=" + tag);
        }
    }
}
