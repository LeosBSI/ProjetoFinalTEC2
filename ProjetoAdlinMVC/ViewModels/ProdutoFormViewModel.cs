using ProjetoAdlinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAdlinMVC.ViewModels
{
    public class ProdutoFormViewModel
    {
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
        public Produto Produto { get; set; }
        public string Title
        {
            get
            {
                if (Produto != null && Produto.Id != 0)
                    return "Editar Produto";

                return "Novo ";
            }
        }
    }
}