using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos;

namespace Negocio
{
    public class NRenta
    {
        private DRenta drenta;

        public NRenta()
        {
            drenta = new DRenta();
        }

        public List<Renta> TodasRentas()
        {
            return drenta.RentaTodas();
        }
        public List<Renta> RentasActivas()
        {
            return drenta.RentaTodas().Where(c => c.Activo == true).ToList();
        }
        public int AgregarRenta(Renta Rentas)
        {
            return drenta.GuardarRenta(Rentas);
        }

        public int EditarRenta(Renta Rentas)
        {
            return drenta.GuardarRenta(Rentas);
        }

        public int EliminarRenta(int RentasId)
        {
            return drenta.EliminarRentas(RentasId);
        }

    }
}
