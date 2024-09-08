using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class PokemonApiService
    {
        private readonly RestClient _client;

        public PokemonApiService()
        {
            _client = new RestClient("https://pokeapi.co/api/v2/");
        }

        public List<MvcResult> ObterEspeciesDisponiveis()
        {
            var request = new RestRequest("pokemon-species", RestSharp.Method.Get); // Alterado para RestSharp.Method.Get
            RestResponse response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Erro ao obter espécies: {response.StatusCode} {response.StatusDescription}");
            }

            var pokemonEspeciesResposta = JsonConvert.DeserializeObject<Species>(response.Content);

            if (pokemonEspeciesResposta == null)
            {
                throw new Exception("Erro ao deserializar a resposta da API.");
            }

            return pokemonEspeciesResposta.Results;
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(MvcResult especie)
        {
            if (string.IsNullOrEmpty(especie.Name))
            {
                throw new ArgumentException("O nome da espécie não pode ser nulo ou vazio.");
            }

            var request = new RestRequest($"pokemon/{especie.Name}", RestSharp.Method.Get); // Alterado para RestSharp.Method.Get
            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Erro ao obter detalhes da espécie: {response.StatusCode} {response.StatusDescription}");
            }

            return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        }
    }
}
