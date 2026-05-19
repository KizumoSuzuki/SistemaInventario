using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data
{
    public class CRUDContext : DbContext
    {
        public CRUDContext (DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD.Models.Producto> Producto { get; set; } = default!;
        public DbSet<CRUD.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<CRUD.Models.Ventas> Ventas { get; set; } = default!;
        public DbSet<CRUD.Models.Usuario> Usuario { get; set; } = default!;
    }
}
