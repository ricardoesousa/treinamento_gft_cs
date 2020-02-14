using System;
using System.Collections.Generic;
using System.Text;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CasaDeShow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        
            : base(options)
        {
        }
    }
}
