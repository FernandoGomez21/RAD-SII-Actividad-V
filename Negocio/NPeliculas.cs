using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.BaseDatos.Models;
using Negocio.Comun;

namespace Negocio
{
    public class NPeliculas
    {
        private DPeliculas dPeliculas;

        public NPeliculas()
        {
            dPeliculas = new DPeliculas();
        }

        public List<Peliculas> TodasLasPeliculas()
        {
            return dPeliculas.PeliculasTodas();
        }

        public List<Peliculas> CategoriasActivas()
        {
            return dPeliculas.PeliculasTodas().Where(c => c.Estado == true).ToList();
        }

        public int Agregarpelicula(Peliculas Peliculas)
        {
            return dPeliculas.GuardarPeliculas(Peliculas);
        }

        public int EditarPeliculas(Peliculas Peliculas)
        {
            return dPeliculas.GuardarPeliculas(Peliculas);
        }

        public int EliminarPeliculas(int PeliculasId)
        {
            return dPeliculas.EliminarPeliculas(PeliculasId);
        }


    }
}
