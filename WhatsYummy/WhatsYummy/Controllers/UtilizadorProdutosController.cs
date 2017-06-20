using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhatsYummy.Models;

namespace WhatsYummy.Controllers
{
    public class UtilizadorProdutosController : Controller
    {
        private WhatsYummyDBEntities db = new WhatsYummyDBEntities();

        // GET: UtilizadorProdutos
        public ActionResult Index()
        {
            var utilizadorProduto = db.UtilizadorProduto.Include(u => u.Produto).Include(u => u.Utilizador);
            return View(utilizadorProduto.ToList());
        }

        // GET: UtilizadorProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilizadorProduto utilizadorProduto = db.UtilizadorProduto.Find(id);
            if (utilizadorProduto == null)
            {
                return HttpNotFound();
            }
            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome");
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username");
            return View();
        }

        // POST: UtilizadorProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilizadorId,ProdutoId,EstabelecimentoId,Favorito")] UtilizadorProduto utilizadorProduto)
        {
            if (ModelState.IsValid)
            {
                db.UtilizadorProduto.Add(utilizadorProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", utilizadorProduto.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", utilizadorProduto.UtilizadorId);
            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilizadorProduto utilizadorProduto = db.UtilizadorProduto.Find(id);
            if (utilizadorProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", utilizadorProduto.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", utilizadorProduto.UtilizadorId);
            return View(utilizadorProduto);
        }

        // POST: UtilizadorProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilizadorId,ProdutoId,EstabelecimentoId,Favorito")] UtilizadorProduto utilizadorProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadorProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", utilizadorProduto.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", utilizadorProduto.UtilizadorId);
            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilizadorProduto utilizadorProduto = db.UtilizadorProduto.Find(id);
            if (utilizadorProduto == null)
            {
                return HttpNotFound();
            }
            return View(utilizadorProduto);
        }

        // POST: UtilizadorProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilizadorProduto utilizadorProduto = db.UtilizadorProduto.Find(id);
            db.UtilizadorProduto.Remove(utilizadorProduto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
