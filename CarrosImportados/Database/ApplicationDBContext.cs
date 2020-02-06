using Microsoft.EntityFrameworkCore;
using CarrosImportados.Models;
using CarrosImportados;


namespace CarrosImportados.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Carro> Carros {get; set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) : base (options) {}
    }
}