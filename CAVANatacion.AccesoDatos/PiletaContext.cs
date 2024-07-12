using Microsoft.EntityFrameworkCore;
using CAVANatacion.AccesoDatos.Entidades;

namespace CAVANatacion.AccesoDatos
{
    public class PiletaContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Presencialidad> Presencialidades { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RODRIGO\\SQLEXPRESS;Database=CAVANatacion;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Plan)
                .WithMany(p => p.Alumnos)
                .HasForeignKey(a => a.PlanId);

            modelBuilder.Entity<Presencialidad>()
                .HasOne(p => p.Alumno)
                .WithMany(a => a.Presencialidades)
                .HasForeignKey(p => p.AlumnoId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Alumno)
                .WithMany(a => a.Pagos)
                .HasForeignKey(p => p.AlumnoId);
        }
    }
}
