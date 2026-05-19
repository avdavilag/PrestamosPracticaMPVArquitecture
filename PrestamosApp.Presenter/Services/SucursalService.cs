using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Repositories;
using PrestamosApp.Model.Entities;
using PrestamosApp.Presenter.DTOs;
using System.Numerics;

namespace PrestamosApp.Presenter.Services
{
    public class SucursalService
    {
        private readonly ISucursales _sucursalesRepository;

        public SucursalService(ISucursales sucursalesRepository)
        {
            _sucursalesRepository = sucursalesRepository;
        }
        public List<Sucursales> GetSucursales() => _sucursalesRepository.GetSucursales();


        public Sucursales ObtenerUnaSucursal(int Id) => _sucursalesRepository.ObtenerUnaSucursal(Id);
        public Sucursales? CreateSucursal(SucursalesDto sdto)
        {

            var Sucursal = new Sucursales
            {
                Nombre = sdto.Nombre,
                Direccion = sdto.Direccion,
                Ciudad = sdto.Ciudad,
                Telefono = sdto.Telefono
            };

            _sucursalesRepository.CreateSucursales(Sucursal);
            return Sucursal;
        }

        public Sucursales ObtenerSucursalPorId(int id) => _sucursalesRepository.ObtenerUnaSucursal(id);
        public Sucursales UpdateSucursal(int Id, SucursalesDto sdto)
        {
            var SucursalExistente = _sucursalesRepository.ObtenerUnaSucursal(Id);
            if (SucursalExistente != null)
            {
                SucursalExistente.Nombre = sdto.Nombre;
                SucursalExistente.Ciudad = sdto.Ciudad;
                SucursalExistente.Telefono = sdto.Telefono;
                SucursalExistente.Direccion = sdto.Direccion;
                SucursalExistente.Telefono = sdto.Telefono;
                _sucursalesRepository.UpdateSucursales(SucursalExistente);
                return SucursalExistente;
            }
            return null;
        }

        public bool DeleteSucursal(int Id)
        {
            var SucursalExistente = _sucursalesRepository.ObtenerUnaSucursal(Id);
            if (SucursalExistente != null)
            {              
              bool flag=_sucursalesRepository.DeleteSucursal(SucursalExistente.Id);
                return flag ? true : false;
            }
            return false;
        }

    }
}