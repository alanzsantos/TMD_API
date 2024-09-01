using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rating_API.Models;

namespace Rating_API.Services
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly TmdbSettings _settings;

        public TmdbService(HttpClient httpClient, IOptions<TmdbSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<Filme> GetMovieByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"movie/{id}?api_key={_settings.ChaveApi}");
            response.EnsureSuccessStatusCode();

            var conteudo = await response.Content.ReadAsStringAsync();
            var respostaFilme = JsonConvert.DeserializeObject<TmdbMovie>(conteudo);

            return new Filme
            {
                Id = respostaFilme.Id,
                Title = respostaFilme.Title,
                Overview = respostaFilme.Overview,
                Rating = respostaFilme.VoteAverage,
                PosterPath = respostaFilme.PosterPath
            };
        }

       
        public async Task<List<Filme>> SearchMoviesAsync(string consulta)
        {
            var resposta = await _httpClient.GetAsync($"search/movie?api_key={_settings.ChaveApi}&query={Uri.EscapeDataString(consulta)}");
            resposta.EnsureSuccessStatusCode();
            var conteudo = await resposta.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TmdbSearchResult>(conteudo);

            if (result == null || result.Results == null)
            {
                return new List<Filme>();
            }

            var filmes = result.Results.Select(filmes => new Filme
            {
                Id = filmes.Id,
                Title = filmes.Title,
                Overview = filmes.Overview,
                Rating = filmes.VoteAverage,
                PosterPath = filmes.PosterPath
            }).ToList();

            return filmes;
        }
        
    }
}
