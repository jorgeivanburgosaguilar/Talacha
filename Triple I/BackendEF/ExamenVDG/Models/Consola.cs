using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExamenVDG.Models
{
    public class Consola
    {
        public byte IdTipoConsola { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public ICollection<Videojuego> Videojuegos { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}