using ApiProdutosPessoas.Data.Map;
using ApiProdutosPessoas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Data
{
    public class ProdutosPessoasdbContext : DbContext
    {
        public ProdutosPessoasdbContext(DbContextOptions<ProdutosPessoasdbContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoModel>()
                .HasOne(p => p.Marca)
                .WithMany()
                .HasForeignKey(p => p.Codigo)
                .HasPrincipalKey(m => m.Codigo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
