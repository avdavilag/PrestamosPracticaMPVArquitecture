using System;

public class TipoPrestamo
{
	
	public int Id { get; set; }
	public string Nombre { get; set; } = string.Empty;
	public int EdadMinima { get; set; }
	public int EdadMaxima { get; set; }
	public List<Prestamo> Prestamos { get; set; } = new();
	
}