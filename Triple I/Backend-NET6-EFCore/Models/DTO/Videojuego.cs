using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamenVDG.Models.DTO
{
    public class Videojuego
    {
        [Key]
        public int IdVideojuego { get; set; }

        [Required, StringLength(256)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public short Anio { get; set; }

        [Required, Range(1, 10)]
        public byte Calificacion { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int IdTipoConsola { get; set; }

        public string NombreConsola { get; set; }

        [Required]
        public int IdTipoGenero { get; set; }

        public string NombreGenero { get; set; }

        [JsonConstructor]
        public Videojuego()
        {
            Titulo =
                Descripcion =
                    NombreConsola =
                        NombreGenero = string.Empty;
            Anio = Convert.ToInt16(DateTime.Today.Year);
            Calificacion = 1;
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
            NombreConsola = videojuego.Consola.Nombre;
            IdTipoGenero = videojuego.IdTipoGenero;
            NombreGenero = videojuego.Genero.Nombre;
        }
    }
}
