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
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Desativa auto-incremento
        public int CodigoMarca { get; set; }
        public string DescricaoMarca { get; set; }
    }
}
