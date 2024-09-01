using System.ComponentModel.DataAnnotations.Schema;

namespace Rating_API.Models
{
    [Table("Filmes")]
    public class Filme
    {
        public int Id { get; set; }

        public int TmdbId { get; set; }

        public string Title { get; set; }

        public string? Overview { get; set; }

        public float Rating { get; set; }

        public string? PosterPath { get; set; }

        public ICollection<FilmeFavorito> FilmeFavoritos { get; set; } = new List<FilmeFavorito>();

    }

    [Table("FilmeFavoritos")]
    public class FilmeFavorito
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MovieId {  get; set; }

        public Filme Filme { get; set; }        
    }
}
