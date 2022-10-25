﻿using System.ComponentModel.DataAnnotations;

namespace ExamenVDG.Models
{
    public class Genero
    {
        [Key]
        public int IdTipoGenero { get; set; }

        [Required, StringLength(256)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
    }
}