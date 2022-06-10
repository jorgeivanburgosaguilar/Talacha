using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenVDG.Models;

namespace ExamenVDG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoJuegosController : ControllerBase
    {
        private readonly ExamenVDGContext _bd;

        public VideoJuegosController(ExamenVDGContext contexto)
        {
            _bd = contexto;
        }

        [HttpGet]
        public IEnumerable<Videojuego> Get()
        {
            return _bd.Videojuegos.Include(vg => vg.Consola).Include(vg => vg.Genero);
        }

        // GET api/<VideoJuegoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VideoJuegoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VideoJuegoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VideoJuegoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
