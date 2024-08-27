using ApiMvc.Models.Entity;
using Microsoft.EntityFrameworkCore;
using ApiMvc.Service.Dtos.Fabricante;
using System.Reflection;

namespace ApiMvc.Models.Cores.Context
{
    public class AppDataBaseContext : DbContext
    {
           
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) { }

        //public DbSet<Producto> Producto { get; set; }
        //public DbSet<Fabricante> Fabricante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.FabricanteId).HasColumnName("Id_Fabricante");

            modelBuilder.Entity<Producto>()
                .HasOne(one => one.Fabricante) // Define la relación uno a uno o muchos a uno
                .WithMany(many => many.Productos) // Si Fabricante tiene una colección de Productos
                .HasForeignKey(fk => fk.FabricanteId); // Especifica la clave foránea

            base.OnModelCreating(modelBuilder);

            // Registrar todas las entidades en el ensamblado actual
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
