using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Models
{
    public class ProdutoModel
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public MarcaModel Marca { get; set; }
        public int EstoqueProduto { get; set; }
    }
}
