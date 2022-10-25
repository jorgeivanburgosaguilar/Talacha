using System.Text.Json.Serialization;

namespace ExamenVDG.Models.DTO
{
    public class Videojuego
    {
        public int IdVideojuego { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public short Anio { get; set; }
        public byte Calificacion { get; set; }
        public int Cantidad { get; set; }
        public int IdTipoConsola { get; set; }
        public int IdTipoGenero { get; set; }

        [JsonConstructor]
        public Videojuego()
        {
            Titulo =
                Descripcion = string.Empty;
        }

        public Videojuego(Models.Videojuego videojuego)
        {
            IdVideojuego = videojuego.IdVideojuego;
            Titulo = videojuego.Titulo;
            Descripcion = videojuego.Descripcion;
            Anio = videojuego.Anio;
            Calificacion = videojuego.Calificacion;
            Cantidad = videojuego.Cantidad;
            IdTipoConsola = videojuego.IdTipoConsola;
            IdTipoGenero = videojuego.IdTipoGenero;
        }
    }
}
