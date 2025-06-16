using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FavorisApiSecure.Models;


namespace FavorisApiSecure.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }
}