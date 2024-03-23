using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DPeliculas
    {
        UnitOfWork _unitOfWork;

        public DPeliculas()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int PeliculasId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Autores { get; set; }
        public int Existencia { get; set; }
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }

        public List<Peliculas> PeliculasTodas()
        {
            return _unitOfWork.Repository<Peliculas>().Consulta().ToList();
        }

        public int GuardarPeliculas(Peliculas categoria)
        {
            if (categoria.PeliculasId == 0)
            {
                _unitOfWork.Repository<Peliculas>().Agregar(categoria);
                return _unitOfWork.Guardar();
            }
            else
            {
                var CategoriaInDb = _unitOfWork.Repository<Peliculas>().Consulta().FirstOrDefault(c => c.PeliculasId == categoria.PeliculasId);

                if (CategoriaInDb != null)
                {
                    CategoriaInDb.Nombre = categoria.Nombre;
                    CategoriaInDb.Genero = categoria.Genero;
                    CategoriaInDb.Autores = categoria.Autores;
                    CategoriaInDb.Existencia = categoria.Existencia;
                    CategoriaInDb.PrecioRenta = categoria.PrecioRenta;
                    CategoriaInDb.Estado = categoria.Estado;
                    _unitOfWork.Repository<Peliculas>().Editar(categoria);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }

        }

        public int EliminarPeliculas(int categoriaId)
        {
            var CategoriaInDb = _unitOfWork.Repository<Peliculas>().Consulta().FirstOrDefault(c => c.PeliculasId == categoriaId);
            if (CategoriaInDb != null)
            {
                _unitOfWork.Repository<Peliculas>().Eliminar(CategoriaInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }



    }
}
