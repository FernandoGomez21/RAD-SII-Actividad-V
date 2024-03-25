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
    public class DClientes
    {

        UnitOfWork _unitOfWork;

        public DClientes()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int clienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Clientes> ClientesTodas()
        {
            return _unitOfWork.Repository<Clientes>().Consulta().ToList();
        }

        public int GuardarClientes(Clientes categoria)
        {
            if (categoria.clienteId == 0)
            {
                _unitOfWork.Repository<Clientes>().Agregar(categoria);
                return _unitOfWork.Guardar();
            }
            else
            {
                var CategoriaInDb = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.clienteId == categoria.clienteId);

                if (CategoriaInDb != null)
                {
                    CategoriaInDb.Nombres = categoria.Nombres;
                    CategoriaInDb.Apellidos = categoria.Apellidos;
                    CategoriaInDb.FechaIngreso = categoria.FechaIngreso;
                    CategoriaInDb.Estado = categoria.Estado;
                    _unitOfWork.Repository<Clientes>().Editar(categoria);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }

        }

        public int EliminarClientes(int ClientesId)
        {
            var ClientesInDb = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.clienteId == ClientesId);
            if (ClientesInDb != null)
            {
                _unitOfWork.Repository<Clientes>().Eliminar(ClientesInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

    }
}
