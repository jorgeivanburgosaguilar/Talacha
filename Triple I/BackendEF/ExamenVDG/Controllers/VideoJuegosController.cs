using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenVDG.Models;

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
        public async Task<ActionResult<IEnumerable<Videojuego>>> GetVideojuegos()
        {
            return await _context.Videojuegos.Include(vg => vg.Consola)
                                 .Include(vg => vg.Genero)
                                 .ToListAsync();
        }

        // GET: api/Videojuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetVideojuego(int id)
        {
            var videojuego = await _context.Videojuegos.Include(vg => vg.Consola)
                                           .Include(vg => vg.Genero)
                                           .FirstOrDefaultAsync(vg => vg.IdVideojuego == id);

            if (videojuego == null)
            {
                return NotFound();
            }

            return Ok(videojuego);
        }

        // PUT: api/Videojuegos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideojuego(int id, Videojuego videojuego)
        {
            if (id != videojuego.IdVideojuego)
            {
                return BadRequest();
            }

            _context.Entry(videojuego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Videojuegos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videojuego>> PostVideojuego(Videojuego videojuego)
        {
            var consola = await _context.Consolas.FindAsync(videojuego.Consola.IdTipoConsola);
            if (consola == null)
            {
                return BadRequest();
            }

            var genero = await _context.Generos.FindAsync(videojuego.Genero.IdTipoGenero);
            if (genero == null)
            {
                return BadRequest();
            }

            videojuego.Consola = consola;
            videojuego.Genero = genero;
            _context.Videojuegos.Add(videojuego);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideojuego), new { id = videojuego.IdVideojuego },
                videojuego);
        }

        // DELETE: api/Videojuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideojuego(int id)
        {
            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideojuegoExists(int id)
        {
            return _context.Videojuegos.Any(e => e.IdVideojuego == id);
        }
    }
}