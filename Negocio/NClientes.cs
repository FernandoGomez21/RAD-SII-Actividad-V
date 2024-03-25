using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos;

namespace Negocio
{
    public class NClientes
    {
        private DClientes dclienetes;

        public NClientes()
        {
            dclienetes = new DClientes();
        }

        public List<Clientes> TodaslosClientes()
        {
            return dclienetes.ClientesTodas();
        }

        public List<Clientes> ClientesActivos()
        {
            return dclienetes.ClientesTodas().Where(c => c.Estado == true).ToList();
        }

        public int AgregarClienets(Clientes Peliculas)
        {
            return dclienetes.GuardarClientes(Peliculas);
        }

        public int EditarClientes(Clientes Peliculas)
        {
            return dclienetes.GuardarClientes(Peliculas);
        }

        public int EliminarClientes(int PeliculasId)
        {
            return dclienetes.EliminarClientes(PeliculasId);
        }


    }
}
