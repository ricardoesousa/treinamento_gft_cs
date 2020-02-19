using System;
using System.Collections.Generic;
using System.Text;
using GerenciadorDeEventos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEventos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
         public DbSet<Evento> Eventos {get; set;}
        public DbSet<Local > Locais {get; set;}
        public DbSet<Venda> Vendas {get; set;}

        /*protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Venda>().HasOne(venda => venda.EventoSelecionado);
        }*/
         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
