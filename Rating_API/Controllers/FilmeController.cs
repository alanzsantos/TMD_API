using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rating_API.Context;
using Rating_API.Models;
using Rating_API.Services;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Rating_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly ITmdbService _tmdbService;
        private readonly AppDbTMContext _context;

        public FilmeController(ITmdbService tmdbService, AppDbTMContext context)
        {
            _tmdbService = tmdbService;
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var filme = await _tmdbService.GetMovieByIdAsync(id);
            return Ok(filme);
        }

        [HttpGet("pesquisar")]
        public async Task<IActionResult> SearchMovies([FromQuery] string consulta)
        {
            if (string.IsNullOrWhiteSpace(consulta))
            {
                return BadRequest("O campo consulta é obrigatório.");
            }

            var filmes = await _tmdbService.SearchMoviesAsync(consulta);
            return Ok(filmes);
        }

        [HttpPost("adicionar-filme")]
        public async Task<IActionResult> AdicionarFilme([FromQuery] int movieId)
        {
            var filme = await _tmdbService.GetMovieByIdAsync(movieId);
            if (filme == null)
            {
                return NotFound("O filme não foi encontrado.");
            }

            var filmeExistente = await _context.Filmes
                .FirstOrDefaultAsync(f => f.TmdbId == movieId);
            if (filmeExistente != null)
            {
                return BadRequest("Esse filme já foi adicionado no banco de dados.");
            }

            var novoFilme = new Filme
            {
                TmdbId = movieId,
                Title = filme.Title,
                Overview = filme.Overview,
                Rating = filme.Rating,
                PosterPath = filme.PosterPath
            };

            _context.Filmes.Add(novoFilme);
            await _context.SaveChangesAsync();

            return Ok(novoFilme);
        }


        [HttpPost("favoritos")]
        public async Task<IActionResult> AddAosFavoritos([FromBody] FilmeFavoritoSolicit request)
        {
            var filmeExistente = await _context.Filmes
                .FirstOrDefaultAsync(f => f.TmdbId == request.MovieId);

            if (filmeExistente == null)
            {
                var filme = await _tmdbService.GetMovieByIdAsync(request.MovieId);
                if (filme == null)
                {
                    return NotFound("Filme não encontrado.");
                }

                filmeExistente = new Filme
                {
                    TmdbId = filme.Id,
                    Title = filme.Title,
                    Overview = filme.Overview,
                    Rating = filme.Rating,
                    PosterPath = filme.PosterPath
                };

                _context.Filmes.Add(filmeExistente);
                await _context.SaveChangesAsync();
            }

            var filmeFavoritoExistente = await _context.FilmeFavoritos
                .FirstOrDefaultAsync(ff => ff.UserId == request.UserId && ff.MovieId == filmeExistente.Id);

            if (filmeFavoritoExistente == null)
            {
                var filmeFavorito = new FilmeFavorito
                {
                    UserId = request.UserId,
                    MovieId = filmeExistente.Id
                };

                _context.FilmeFavoritos.Add(filmeFavorito);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Este filme já está na sua lista de favoritos!");
            }

            return Ok(new { Message = "Filme adicionado aos favoritos com sucesso." });
        }       


        [HttpGet("favoritos/{userId}")]
        public async Task<IActionResult> ObterFavoritos(string userId)
        {
            var favoritos = await _context.FilmeFavoritos
                .Where(ff => ff.UserId == userId)
                .Include(ff => ff.Filme)
                .ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return Ok(favoritos);
        }

        [HttpDelete("favoritos/{movieId}/{userId}")]
        public async Task<IActionResult> RemoverDosFavoritos(int movieId, string userId)
        {                     

            var filmeFavorito = await _context.FilmeFavoritos
                .FirstOrDefaultAsync(ff => ff.UserId == userId && ff.MovieId == movieId);

            if (filmeFavorito == null)
            {
                return NotFound("Seu filme favorito não foi encontrado.");
            }

            _context.FilmeFavoritos.Remove(filmeFavorito);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("compartilhar/{userId}")]
        public IActionResult CompartilharFavoritos(string userId)
        {
            var linkCompartilhamento = Url.Action("ObterFavoritos", "Filme", new { userId }, protocol: HttpContext.Request.Scheme);
            return Ok(new { Link = linkCompartilhamento });
        }
    }
}

