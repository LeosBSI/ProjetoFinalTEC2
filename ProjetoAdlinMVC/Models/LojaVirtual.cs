using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAdlinMVC.Models
{
    public class LojaVirtual
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String NomeLoja { get; set; }

        [Required]
        [StringLength(255)]
        public String Cnpj { get; set; }
    }
}