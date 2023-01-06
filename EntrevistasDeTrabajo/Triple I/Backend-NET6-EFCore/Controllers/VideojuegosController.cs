using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenVDG.Models;
using VideojuegoDTO = ExamenVDG.Models.DTO.Videojuego;

namespace ExamenVDG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideojuegosController : ControllerBase
    {
        private readonly ExamenVDGContext _context;

        public VideojuegosController(ExamenVDGContext context)
        {
            _context = context;
        }

        // GET: api/Videojuegos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideojuegoDTO>>> GetVideojuegos()
        {
            return await _context.Videojuegos.Include(v => v.Consola)
                                 .Include(v => v.Genero)
                                 .Select(v => ToDTO(v))
                                 .ToListAsync();
        }

        // GET: api/Videojuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideojuegoDTO>> GetVideojuego(int id)
        {
            var videojuego = await _context.Videojuegos.Include(v => v.Consola)
                                           .Include(v => v.Genero)
                                           .FirstOrDefaultAsync(v => v.IdVideojuego == id);

            if (videojuego == null)
                return NotFound();

            return ToDTO(videojuego);
        }

        // PUT: api/Videojuegos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideojuego(int id, VideojuegoDTO videojuegoDTO)
        {
            if (id != videojuegoDTO.IdVideojuego)
                return BadRequest();

            if (!VideojuegoExists(id))
                return NotFound();

            var consola =
                await _context.Consolas.AnyAsync(
                    c => c.IdTipoConsola == videojuegoDTO.IdTipoConsola);
            if (!consola)
                return BadRequest();

            var genero =
                await _context.Generos.AnyAsync(g => g.IdTipoGenero == videojuegoDTO.IdTipoGenero);
            if (!genero)
                return BadRequest();

            var vg = new Videojuego(videojuegoDTO);
            _context.Entry(vg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // POST: api/Videojuegos
        [HttpPost]
        public async Task<ActionResult<VideojuegoDTO>> PostVideojuego(VideojuegoDTO videojuegoDTO)
        {
            var consola =
                await _context.Consolas.AnyAsync(
                    c => c.IdTipoConsola == videojuegoDTO.IdTipoConsola);
            if (!consola)
                return BadRequest();

            var genero =
                await _context.Generos.AnyAsync(g => g.IdTipoGenero == videojuegoDTO.IdTipoGenero);
            if (!genero)
                return BadRequest();

            var vg = new Videojuego(videojuegoDTO);
            _context.Entry(vg).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideojuego), new { id = vg.IdVideojuego }, ToDTO(vg));
        }

        // DELETE: api/Videojuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideojuego(int id)
        {
            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego == null)
                return NotFound();

            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideojuegoExists(int id)
        {
            return _context.Videojuegos.Any(e => e.IdVideojuego == id);
        }

        private static VideojuegoDTO ToDTO(Videojuego videojuego)
        {
            return new VideojuegoDTO(videojuego);
        }
    }
}
