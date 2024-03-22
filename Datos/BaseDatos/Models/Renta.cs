using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Renta
    {
        [Key]
        public int RentaId { get; set; }
        public int clienteId { get; set; }
        public Clientes cliente { get; set; }
        public int PeliculasId { get; set; }
        public Peliculas Peliculas { get; set; }
        [Required]
        public DateTime FechaRenta { get; set; }
        [Required]
        public DateTime FechaRetorno { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }

    }
}
