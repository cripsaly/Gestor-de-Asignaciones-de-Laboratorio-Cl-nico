using Microsoft.EntityFrameworkCore;
using LabClinicoAPI.Models;

namespace LabClinicoAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
    }
}