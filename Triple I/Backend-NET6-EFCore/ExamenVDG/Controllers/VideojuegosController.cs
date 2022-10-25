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
        public async Task<ActionResult<IEnumerable<Models.DTO.Videojuego>>> GetVideojuegos()
        {
            return await _context.Videojuegos.Include(v => v.Consola)
                                 .Include(v => v.Genero)
                                 .Select(v => ToDTO(v))
                                 .ToListAsync();
        }

        // GET: api/Videojuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DTO.Videojuego>> GetVideojuego(int id)
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
        public async Task<IActionResult> PutVideojuego(int id, Models.DTO.Videojuego videojuego)
        {
            if (id != videojuego.IdVideojuego)
                return BadRequest();

            if (!VideojuegoExists(id))
                return NotFound();

            // ToDo Replace this with any?
            var consola = await _context.Consolas.FindAsync(videojuego.IdTipoConsola);
            if (consola == null)
                return BadRequest();

            var genero = await _context.Generos.FindAsync(videojuego.IdTipoGenero);
            if (genero == null)
                return BadRequest();

            var vg = new Videojuego(videojuego);
            vg.Consola = consola;
            vg.Genero = genero;
            _context.Entry(vg).State = EntityState.Modified;

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

                throw;
            }

            return NoContent();
        }

        // POST: api/Videojuegos
        [HttpPost]
        public async Task<ActionResult<Models.DTO.Videojuego>> PostVideojuego(
            Models.DTO.Videojuego videojuego)
        {
            // ToDo Replace this with any?
            var consola = await _context.Consolas.FindAsync(videojuego.IdTipoConsola);
            if (consola == null)
                return BadRequest();

            var genero = await _context.Generos.FindAsync(videojuego.IdTipoGenero);
            if (genero == null)
                return BadRequest();

            var vg = new Videojuego(videojuego);
            vg.Consola = consola;
            vg.Genero = genero;
            _context.Videojuegos.Add(vg);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideojuego), new { id = vg.IdVideojuego }, ToDTO(vg));
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

        private static Models.DTO.Videojuego ToDTO(Videojuego videojuego)
        {
            return new Models.DTO.Videojuego(videojuego);
        }
    }
}
