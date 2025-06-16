using Microsoft.EntityFrameworkCore;
using FavorisApiSecure.Models;
using FavorisApiSecure.Models;

namespace FavorisApiSecure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Favori> Favoris { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

    }
}