﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Peliculas
    {

        [Key]
        public int PeliculasId { get; set; }
        [Required]
        [MaxLength(75)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(30)]
        public string Genero { get; set; }
        [Required]
        [MaxLength(75)]
        public string Autores { get; set; }
        public int Existencia { get; set; }
        [Required]
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }


    }
}
