using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamenVDG.Models
{
    public class Consola
    {
        [Key]
        public int IdTipoConsola { get; set; }

        [Required, StringLength(256, MinimumLength = 1)]
        public string Nombre { get; set; }

        public ICollection<Videojuego> Videojuegos { get; set; }

        [JsonConstructor]
        public Consola()
        {
            IdTipoConsola = 0;
            Nombre = string.Empty;
            Videojuegos = new List<Videojuego>();
        }

        public Consola(int idTipoConsola)
        {
            IdTipoConsola = idTipoConsola;
            Nombre = string.Empty;
            Videojuegos = new List<Videojuego>();
        }
    }
}