using Rating_API.Models;

namespace Rating_API.Services
{
    public interface ITmdbService
    {        
        Task<Filme> GetMovieByIdAsync(int id);

        Task<List<Filme>> SearchMoviesAsync(string consulta);

    }
}
