using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FavorisApiSecure.Data;
using FavorisApiSecure.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System;

namespace FavorisApiSecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavorisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavorisController(AppDbContext context)
        {
            _context = context;
        }

        private int GetUserId()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type.EndsWith("nameidentifier"));
            if (claim == null)
                throw new Exception("Impossible de trouver l'ID utilisateur dans le token.");

            return int.Parse(claim.Value);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = GetUserId();
            var favoris = _context.Favoris.Where(f => f.UtilisateurId == userId).ToList();
            return Ok(favoris);
        }

        [HttpPost]
        public IActionResult Post(Favori favori)
        {
            favori.UtilisateurId = GetUserId();
            _context.Favoris.Add(favori);
            _context.SaveChanges();
            return Ok(favori);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();
            var favori = _context.Favoris.FirstOrDefault(f => f.Id == id && f.UtilisateurId == userId);
            if (favori == null)
                return NotFound();

            _context.Favoris.Remove(favori);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
