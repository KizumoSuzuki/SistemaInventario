using Microsoft.EntityFrameworkCore;

public class SistemaInventarioContext(DbContextOptions<SistemaInventarioContext> options) : DbContext(options)
{
    public DbSet<SistemaInventario.Models.Entities.Categoria> Categoria { get; set; } = default!;
}
