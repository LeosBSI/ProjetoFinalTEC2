using ProjetoAdlinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjetoAdlinMVC.ViewModels;

namespace ProjetoAdlinMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private ApplicationDbContext _context;

        public ProdutoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var produtos = _context.Produtos.Include(c => c.Fornecedor).ToList();
            return View(produtos);
        }

        public ActionResult Details(int id)
        {
            var produto = _context.Produtos.Include(c => c.Fornecedor).SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        public ActionResult New()
        {
            var fornecedor = _context.Fornecedores.ToList();
            var viewModel = new ProdutoFormViewModel
            {
                Produto = new Produto(),
                Fornecedores = fornecedor
            };

            return View("ProdutoForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel
                {
                    Produto = produto,
                    Fornecedores = _context.Fornecedores.ToList()
                };

                return View("ProdutoForm", viewModel);
            }

            if (produto.Id == 0)
            {
                // armazena o cliente em memória
                _context.Produtos.Add(produto);
            }
            else
            {
                var produtoInDb = _context.Produtos.Single(c => c.Id == produto.Id);

                produtoInDb.Nome = produto.Nome;
                produtoInDb.TipoProduto = produto.TipoProduto;
                produtoInDb.Preco = produto.Preco;
                produtoInDb.FornecedorId = produto.FornecedorId;

            }

            // faz a persistência
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            var viewModel = new ProdutoFormViewModel
            {
                Produto = produto,
                Fornecedores = _context.Fornecedores.ToList()
            };

            return View("ProdutoForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}