using Microsoft.EntityFrameworkCore.Query.Internal;
using PrestamosApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosApp.Data.Interfaces
{
   public interface ISucursales
   {
        List<Sucursales> GetSucursales();
        void CreateSucursales(Sucursales Sucursal);
        Sucursales UpdateSucursales(Sucursales sucursal);
        bool DeleteSucursal(int Id);
        Sucursales ObtenerUnaSucursal(int Id);
    }
}
