using System.Text.Json.Serialization;

namespace ExamenVDG.Models
{
    public class Videojuego
    {
        public int IdVideojuego { get; set; }

        [JsonIgnore]
        public byte IdTipoConsola { get; set; }

        [JsonIgnore]
        public byte IdTipoGenero { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public short Anio { get; set; }
        public byte Calificacion { get; set; }
        public int Cantidad { get; set; }

        public virtual Consola Consola { get; set; }
        public virtual Genero Genero { get; set; }

        public override string ToString()
        {
            return Titulo;
        }
    }
}