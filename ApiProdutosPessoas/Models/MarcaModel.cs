using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Models
{
    public class MarcaModel
    {
        [Key]
        public int CodigoMarca { get; set; }

        [Required(ErrorMessage = "A descrição da marca é obrigatória")]
        public string DescricaoMarca { get; set; }
    }
}
