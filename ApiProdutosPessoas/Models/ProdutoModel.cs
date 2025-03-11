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
        public string DescricaoProduto { get; set; }
        public int EstoqueProduto { get; set; }

        // Relação direta usando CodigoMarca
        public int CodigoMarca { get; set; }  // Esta é a chave estrangeira

        // Propriedade de navegação
        public MarcaModel Marca { get; set; }
    }
}
