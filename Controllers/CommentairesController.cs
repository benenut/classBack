using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FavorisApiSecure.Models;
using FavorisApiSecure.Data;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace FavorisApiSecure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentairesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentairesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{tmdbId}")]
        public IActionResult GetCommentaires(string tmdbId)
        {
            var commentaires = _context.Commentaires
                .Where(c => c.TmdbId == tmdbId)
                .OrderByDescending(c => c.Date)
                .ToList();

            return Ok(commentaires);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Commentaire commentaire)
        {
            commentaire.Date = DateTime.UtcNow;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return Ok(commentaire);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
                return NotFound();

            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
