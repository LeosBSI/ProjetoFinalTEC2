using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAdlinMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string TipoProduto { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public Fornecedor Fornecedor { get; set; }

        public int FornecedorId { get; set; }
    }
}