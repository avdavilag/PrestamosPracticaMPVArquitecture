namespace PrestamosApp.Model.Entities;
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public int Edad { get; set; };
    public string FechaRegistro { get; set; } = string.Empty;
    public List<Prestamo> Prestamos { get; set; } = new(); 

    }