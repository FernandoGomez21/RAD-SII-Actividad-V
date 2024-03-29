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
    public class DRenta
    {
        UnitOfWork _unitOfWork;

        public DRenta()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int RentaId { get; set; }
        public int clienteId { get; set; }
        public Clientes cliente { get; set; }
        public int PeliculasId { get; set; }
        public Peliculas Peliculas { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaRetorno { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }

        public bool Activo { get; set; }

        public List<Renta> RentaTodas()
        {
            return _unitOfWork.Repository<Renta>().Consulta().ToList();
        }

        public int GuardarRenta(Renta Rentas)
        {
            if (Rentas.RentaId == 0)
            {
                _unitOfWork.Repository<Renta>().Agregar(Rentas);
                return _unitOfWork.Guardar();
            }
            else
            {
                var CategoriaInDb = _unitOfWork.Repository<Renta>().Consulta().FirstOrDefault(c => c.RentaId == Rentas.RentaId);

                if (CategoriaInDb != null)
                {
                    CategoriaInDb.RentaId = Rentas.RentaId;
                    CategoriaInDb.clienteId = Rentas.clienteId;
                    CategoriaInDb.PeliculasId = Rentas.PeliculasId;
                    CategoriaInDb.FechaRenta = Rentas.FechaRenta;
                    CategoriaInDb.FechaRetorno = Rentas.FechaRetorno;
                    CategoriaInDb.Cantidad = Rentas.Cantidad;
                    CategoriaInDb.PrecioRenta = Rentas.PrecioRenta;
                    CategoriaInDb.Activo = Rentas.Activo;
                    _unitOfWork.Repository<Renta>().Editar(Rentas);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }

        }

        public int EliminarRentas(int RentasId)
        {
            var RentasaInDb = _unitOfWork.Repository<Renta>().Consulta().FirstOrDefault(c => c.RentaId == RentasId);
            if (RentasaInDb != null)
            {
                _unitOfWork.Repository<Renta>().Eliminar(RentasaInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

    }
}
