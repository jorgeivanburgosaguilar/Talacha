using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamenVDG.Models
{
    public class Genero
    {
        [Key]
        public int IdTipoGenero { get; set; }

        [Required, StringLength(256, MinimumLength = 1)]
        public string Nombre { get; set; }

        public ICollection<Videojuego> Videojuegos { get; set; }

        [JsonConstructor]
        public Genero()
        {
            IdTipoGenero = 0;
            Nombre = string.Empty;
            Videojuegos = new List<Videojuego>();
        }

        public Genero(int idTipoGenero)
        {
            IdTipoGenero = idTipoGenero;
            Nombre = string.Empty;
            Videojuegos = new List<Videojuego>();
        }
    }
}