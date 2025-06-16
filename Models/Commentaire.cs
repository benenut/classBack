using System;
using System.ComponentModel.DataAnnotations;

namespace FavorisApiSecure.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        [Required]
        public string TmdbId { get; set; }


        [Required]
        public string Nom { get; set; }

        [Required]
        public string Contenu { get; set; }

        [Range(1, 5)]
        public int Note { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
