using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Enums;
using SistemaInventario.Models.Entities;
using System;
using System.Linq;

namespace SistemaInventario.Data
{
    public static class DbSeeder
    {
        public static void SeedSuperAdmin(ApplicationDbContext context)
        {
            // Validar si ya existe el SuperAdmin
            if (!context.Usuarios.Any(u => u.Rol == Rol.SuperAdmin))
            {
                var superAdmin = new Usuario
                {
                    Nombre = "Super Administrador",
                    Email = "admin", 
                    Contraseña = "admin", 
                    Telefono = "0000000000",
                    Rol = Rol.SuperAdmin
                };

                context.Usuarios.Add(superAdmin);
                context.SaveChanges();
            }
        }
    }
}
