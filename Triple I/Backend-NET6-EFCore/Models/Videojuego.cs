namespace ExamenVDG.Models
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
        public Consola? Consola { get; set; }

        public int IdTipoGenero { get; set; }
        public Genero? Genero { get; set; }

        public Videojuego()
        {
            IdVideojuego = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            Anio = Convert.ToInt16(DateTime.Today.Year);
            Calificacion = 1;
            Cantidad = 1;
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
            IdTipoGenero = videojuego.IdTipoGenero;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}