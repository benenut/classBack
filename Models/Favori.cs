using System.ComponentModel.DataAnnotations;

namespace FavorisApiSecure.Models
{
    public class Favori
    {
        public int Id { get; set; }

        [Required]
        public int UtilisateurId { get; set; }

        [Required]
        public int TmdbId { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty; // "movie" ou "tv"

        [Required]
        public string Titre { get; set; } = string.Empty;

        public string PosterPath { get; set; } = string.Empty;

        public Utilisateur? Utilisateur { get; set; }
    }
}
