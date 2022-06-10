using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExamenVDG.Models
{
    public class Genero
    {
        public byte IdTipoGenero { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Videojuego> Videojuegos { get; set; }

        public Genero()
        {
            Videojuegos = new HashSet<Videojuego>();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}