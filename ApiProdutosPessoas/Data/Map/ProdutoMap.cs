using ApiProdutosPessoas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.CodigoProduto);
            builder.Property(x => x.DescricaoProduto).IsRequired().HasMaxLength(255).IsUnicode();
            builder.Property(x => x.EstoqueProduto).IsRequired();

            builder.HasOne(x => x.Marca).WithMany().HasForeignKey(x => x.MarcaId);
        }
    }
}
