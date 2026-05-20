using Microsoft.EntityFrameworkCore;
using SistemaInventario.Enums;
using SistemaInventario.Models.Entities;
namespace SistemaInventario.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<AlmacenProducto> AlmacenProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlmacenProducto>()
        .HasKey(ap => new { ap.AlmacenId, ap.ProductoId });

            // Relación Almacen -> AlmacenProducto
            modelBuilder.Entity<AlmacenProducto>()
                .HasOne(ap => ap.Almacen)
                .WithMany(a => a.AlmacenProductos)
                .HasForeignKey(ap => ap.AlmacenId);

            // Relación Producto -> AlmacenProducto
            modelBuilder.Entity<AlmacenProducto>()
                .HasOne(ap => ap.Producto)
                .WithMany(p => p.AlmacenProductos)
                .HasForeignKey(ap => ap.ProductoId);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.Productoid)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany()
                .HasForeignKey(c => c.Proveedorid)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Almacen)
                .WithMany()
                .HasForeignKey(c => c.Almacenid)
                .OnDelete(DeleteBehavior.Restrict);

            // SuperAdmin por defecto (contraseña: admin, guardada como SHA-256)
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nombre = "Super Administrador",
                Email = "admin",
                Contraseña = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", // SHA-256 de "admin"
                Telefono = "0000000000",
                Rol = Rol.SuperAdmin
            });
        }
    }
}
