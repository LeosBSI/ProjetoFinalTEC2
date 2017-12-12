using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAdlinMVC.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String NomeEmpresa { get; set; }

        [Required]
        [StringLength(255)]
        public String Cnpj { get; set; }

        [Required]
        [StringLength(255)]
        public String Cidade { get; set; }
    }
}