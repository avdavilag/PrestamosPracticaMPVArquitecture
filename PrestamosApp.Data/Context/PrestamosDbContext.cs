using System;
using Microsoft.EntityFrameworkCore;
using PrestamosApp.Model.Entities;


namespace PrestamosApp.Data.Context;


public class PrestamosDbContext : DbContext
{
	public PrestamosDbContext(DbContextOptions<PrestamosDbContext> options) : base(options) { }

	public DbSet<Cliente> Clientes { get; set; } = null!;
	public DbSet<TipoPrestamo> TipoPrestamo { get; set; } = null!;
	public DbSet<Prestamo> Prestamos { get; set; } = null!;
    public DbSet<Sucursales> Sucursales { get; set; } = null!;
	public DbSet<Roles> Roles { get; set; } = null!;
    public DbSet<Usuarios> Usuarios { get; set; } = null!;
	public DbSet<CuotaPrestamo> CuotaPrestamos{ get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Prestamo>()
			.HasOne(p => p.Cliente)
			.WithMany(c => c.Prestamos)
			.HasForeignKey(p => p.ClienteId);

		modelBuilder.Entity<Prestamo>()
			.HasOne(p => p.TipoPrestamo)
			.WithMany(t => t.Prestamos)
			.HasForeignKey(p => p.TipoPrestamoId);

		modelBuilder.Entity<Prestamo>()
				.HasOne(p => p.Sucursales)
				.WithMany(s => s.Prestamos)
				.HasForeignKey(s => s.SucursalesId);

		modelBuilder.Entity<Prestamo>()
			.Property(p => p.Monto)
			.HasPrecision(18,2);

		modelBuilder.Entity<Usuarios>()
			.HasOne(u => u.Rol)
			.WithMany(r=>r.Usuarios)
			.HasForeignKey(u=>u.RolId);


        modelBuilder.Entity<Usuarios>()
			.HasOne(u => u.Cliente)
			.WithMany()
    .		HasForeignKey(u => u.ClienteId);

		modelBuilder.Entity<Usuarios>()
			 .HasIndex(u => u.Email)
			 .IsUnique();

		modelBuilder.Entity<CuotaPrestamo>()
			.HasOne(c => c.Prestamo)
			.WithMany(p => p.CuotaPrestamo)
			.HasForeignKey(c => c.PrestamoId);


        modelBuilder.Entity<TipoPrestamo>().HasData( 
			new TipoPrestamo { Id = 1, Nombre = "Prestamo Infanto", EdadMinima = 0, EdadMaxima = 18 },
			new TipoPrestamo { Id = 2, Nombre = "Prestamo Mediana Edad", EdadMinima = 19, EdadMaxima = 50 },
			new TipoPrestamo { Id = 3, Nombre = "Prestamo Adultos", EdadMinima = 51, EdadMaxima = 120 }
			);
    }
}

