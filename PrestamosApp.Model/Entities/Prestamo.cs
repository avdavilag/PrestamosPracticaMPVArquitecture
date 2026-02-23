
using PrestamosApp.Model.Entities;
using System;

public class Prestamo
{
	public int Id { get; set; }
	public int ClienteId { get; set; }
	public int TipoPrestamoId { get; set; }
	public decimal Monto { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
	public string Estado { get; set; } = string.Empty;
		
	public Cliente Cliente { get; set; } = null!;
	public TipoPrestamo TipoPrestamo { get; set; } = null!;

}

