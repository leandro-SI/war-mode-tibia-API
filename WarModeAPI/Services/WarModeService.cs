using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WarModeAPI.Models;
using WarModeAPI.Models.Response;
using WarModeAPI.Services.Interface;
using WarModeAPI.WarModeConfig;

namespace WarModeAPI.Services
{
    public class WarModeService : IWarModeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TibiaDataConfig _tibiaDataConfig;

        public WarModeService(IHttpClientFactory httpClientFactory, IOptions<TibiaDataConfig> tibiaDataConfig)
        {
            _httpClientFactory = httpClientFactory;
            _tibiaDataConfig = tibiaDataConfig.Value;
        }


        public async Task<Personagem> GetPersonagem(string nome)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("TibiaData"))
            {

                nome = nome.Replace(" ", "+");

                string url = $"{(httpClient.BaseAddress.AbsolutePath == "/" ? string.Empty : httpClient.BaseAddress.AbsolutePath + "/")}" +
                    $"{_tibiaDataConfig.Versao}/character/{nome}";

                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                string responseString = await httpResponseMessage.Content.ReadAsStringAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    PersonagemApiResponse personagemApiResponse = JsonConvert.DeserializeObject<PersonagemApiResponse>(responseString);


                    if (!string.IsNullOrEmpty(personagemApiResponse.Characters.character.Name))
                    {
                        return new Personagem
                        {
                            Name = personagemApiResponse.Characters.character.Name,
                            Sex = personagemApiResponse.Characters.character.Sex,
                            Vocation = personagemApiResponse.Characters.character.Vocation,
                            Level = personagemApiResponse.Characters.character.Level,
                            World = personagemApiResponse.Characters.character.World,
                            Residence = personagemApiResponse.Characters.character.Residence,
                            Last_login = Convert.ToDateTime(personagemApiResponse.Characters.character.Last_login),
                            Account_status = personagemApiResponse.Characters.character.Account_status
                        };
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    throw new Exception("Erro ao buscar personagem.");
                }


            }
        }

    }
}
