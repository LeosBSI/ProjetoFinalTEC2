
using ProjetoAdlinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAdlinMVC.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;


        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {

            var cliente = _context.Clientes.ToList();
            return View(cliente);
        }

        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        public ActionResult New()
        {
            var cliente = new Cliente();

            return View("ClienteForm", cliente);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return View("ClienteForm", cliente);
            }

            if (cliente.Id == 0)
            {
                // armazena o cliente em memória
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                clienteInDb.Nome = cliente.Nome;
                clienteInDb.Cpf = cliente.Cpf;

            }

            // faz a persistência
            _context.SaveChanges();

            return RedirectToAction("Index");
            // Voltamos para a lista de clientes
        }

        public ActionResult Edit(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();


            return View("ClienteForm", cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}