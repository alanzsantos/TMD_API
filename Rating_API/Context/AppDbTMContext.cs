using Microsoft.EntityFrameworkCore;
using Rating_API.Models;

namespace Rating_API.Context
{
    public class AppDbTMContext : DbContext
    {
        public AppDbTMContext(DbContextOptions<AppDbTMContext> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<FilmeFavorito> FilmeFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilmeFavorito>()
                .HasOne(ff => ff.Filme)
                .WithMany(f => f.FilmeFavoritos)
                .HasForeignKey(ff => ff.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
