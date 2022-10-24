using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public int IdTipoConsola { get; set; }

    public Consola Consola { get; set; }

    [JsonIgnore]
    public int IdTipoGenero { get; set; }

    public Genero Genero { get; set; }

    public override string ToString()
    {
      return Titulo;
    }
  }
}