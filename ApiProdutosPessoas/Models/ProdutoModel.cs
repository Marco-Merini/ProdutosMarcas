using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        [Column("Codigo")]
        public int Codigo { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Estoque")]
        public int Estoque { get; set; }
        [Column("Cod_Marca")]
        public int CodigoMarca { get; set; }
    }
}
