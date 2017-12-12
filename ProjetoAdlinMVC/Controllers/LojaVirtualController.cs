using ProjetoAdlinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAdlinMVC.Controllers
{
    public class LojaVirtualController : Controller
    {
        private ApplicationDbContext _context;

        public LojaVirtualController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {

            var lojavirtual = _context.LojasVituais.ToList();
            return View(lojavirtual);
        }

        public ActionResult Details(int id)
        {
            var lojavirtual = _context.LojasVituais.SingleOrDefault(c => c.Id == id);
            if (lojavirtual == null)
            {
                return HttpNotFound();
            }

            return View(lojavirtual);
        }

        public ActionResult New()
        {
            var lojavirtual = new LojaVirtual();

            return View("LojaVirtualForm", lojavirtual);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(LojaVirtual lojaVirtual)
        {

            if (!ModelState.IsValid)
            {
                return View("LojaVirtualForm", lojaVirtual);
            }

            if (lojaVirtual.Id == 0)
            {
                // armazena o cliente em memória
                _context.LojasVituais.Add(lojaVirtual);
            }
            else
            {
                var lojavirtualInDb = _context.LojasVituais.Single(c => c.Id == lojaVirtual.Id);

                lojavirtualInDb.Id = lojaVirtual.Id;
                lojavirtualInDb.NomeLoja = lojaVirtual.NomeLoja;
                lojavirtualInDb.Cnpj = lojaVirtual.Cnpj;

            }

            // faz a persistência
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var lojavirtual = _context.LojasVituais.SingleOrDefault(c => c.Id == id);

            if (lojavirtual == null)
                return HttpNotFound();


            return View("LojaVirtualForm", lojavirtual);
        }

        public ActionResult Delete(int id)
        {
            var lojavirtual = _context.LojasVituais.SingleOrDefault(c => c.Id == id);

            if (lojavirtual == null)
                return HttpNotFound();

            _context.LojasVituais.Remove(lojavirtual);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}