using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAdlinMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        [StringLength(255)]
        public String Cpf { get; set; }
    }
}