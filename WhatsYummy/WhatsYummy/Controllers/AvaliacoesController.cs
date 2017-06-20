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
    public class AvaliacoesController : Controller
    {
        private WhatsYummyDBEntities db = new WhatsYummyDBEntities();

        // GET: Avaliacoes
        public ActionResult Index()
        {
            var avaliacao = db.Avaliacao.Include(a => a.Produto).Include(a => a.Utilizador);
            return View(avaliacao.ToList());
        }

        // GET: Avaliacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacoes/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome");
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username");
            return View();
        }

        // POST: Avaliacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Classificaçao,Comentario,UtilizadorId,ProdutoId,EstabelecimentoId,Foto")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacao.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", avaliacao.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", avaliacao.UtilizadorId);
            return View(avaliacao);
        }

        // GET: Avaliacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", avaliacao.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", avaliacao.UtilizadorId);
            return View(avaliacao);
        }

        // POST: Avaliacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Classificaçao,Comentario,UtilizadorId,ProdutoId,EstabelecimentoId,Foto")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "ID", "Nome", avaliacao.ProdutoId);
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", avaliacao.UtilizadorId);
            return View(avaliacao);
        }

        // GET: Avaliacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            db.Avaliacao.Remove(avaliacao);
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
