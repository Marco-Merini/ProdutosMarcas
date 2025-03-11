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
        public int EstoqueProduto { get; set; }
        public int MarcaId { get; set; }  // Adicionar esta propriedade para o ID da marca
        public MarcaModel Marca { get; set; }

    }
}
