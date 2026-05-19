using PrestamosApp.Data.Interfaces;
using PrestamosApp.Data.Repositories;
using PrestamosApp.Model.Entities;
using PrestamosApp.Presenter.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace PrestamosApp.Presenter.Services
{
    public class CuotaService
    {
        private readonly ICuotaRepository _cuotaRepository;
        public CuotaService(ICuotaRepository cuotaRepository)
        {
            _cuotaRepository = cuotaRepository;
        }
        public List<CuotaPrestamo> GetCuotasByPrestamoIdAsync(int prestamoId)
         => _cuotaRepository.GetCuotasByPrestamoIdAsync(prestamoId);

        public CuotaPrestamo? GetCuotaByIdAsync(int id) => _cuotaRepository.GetCuotaByIdAsync(id);

        public void GenerarTablaAmortizacion(int prestamoId, int numeroCuota, decimal tasaInteres) => _cuotaRepository.GenerarTablaAmortizacion(prestamoId, numeroCuota, tasaInteres);

        public void RegistrarPago(int cuotaId) => _cuotaRepository.RegistrarPago(cuotaId);



    }
}
