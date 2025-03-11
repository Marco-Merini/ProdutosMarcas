using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Models
{
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória")]
        public string DescricaoProduto { get; set; }

        public int EstoqueProduto { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoMarca { get; set; }

        public MarcaModel Marca { get; set; }
    }
}
