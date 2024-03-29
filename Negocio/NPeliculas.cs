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
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var categorias = CategoriasActivas().Select(c => new
            {
                c.PeliculasId,
                c.Nombre,
                c.PrecioRenta,
            })
                                      .ToList();
            foreach (var item in categorias)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.PeliculasId,
                    Nombres= item.Nombre,
                    PrecioRenta = item.PrecioRenta
                });;
            }

            return Datos;
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
