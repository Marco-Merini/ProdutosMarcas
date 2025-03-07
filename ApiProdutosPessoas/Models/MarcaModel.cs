using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Models
{
    [Table("Marcas")]
    public class MarcaModel
    {
        [Key]
        [Column("Cod_Marca")]
        public int CodigoMarca { get; set; }

        [Column("Descricao")]
        public string DescricaoMarca { get; set; }

        public List<ProdutoModel> Produtos { get; set; }
    }
}
