using System.ComponentModel.DataAnnotations;

namespace ExamenVDG.Models
{
    public class Consola
    {
        [Key]
        public int IdTipoConsola { get; set; }

        [Required, StringLength(256, MinimumLength = 1)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
    }
}