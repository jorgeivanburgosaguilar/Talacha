using System.ComponentModel.DataAnnotations;

namespace ExamenVDG.Models
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

        public Consola Consola { get; set; }

        [Required]
        public int IdTipoGenero { get; set; }

        public Genero Genero { get; set; }

        public Videojuego()
        {
            Titulo =
                Descripcion = string.Empty;
            Anio = Convert.ToInt16(DateTime.Today.Year);
            Calificacion = 1;
            Consola = new Consola();
            Genero = new Genero();
        }

        public Videojuego(DTO.Videojuego videojuego)
        {
            IdVideojuego = videojuego.IdVideojuego;
            Titulo = videojuego.Titulo;
            Descripcion = videojuego.Descripcion;
            Anio = videojuego.Anio;
            Calificacion = videojuego.Calificacion;
            Cantidad = videojuego.Cantidad;
            IdTipoConsola = videojuego.IdTipoConsola;
            Consola = new Consola();
            IdTipoGenero = videojuego.IdTipoGenero;
            Genero = new Genero();
        }
    }
}