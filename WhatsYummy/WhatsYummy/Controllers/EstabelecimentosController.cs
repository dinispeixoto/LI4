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
    public class EstabelecimentosController : Controller
    {
        private WhatsYummyDBEntities db = new WhatsYummyDBEntities();

        // GET: Estabelecimentos
        public ActionResult Index()
        {
            var estabelecimento = db.Estabelecimento.Include(e => e.Utilizador);
            return View(estabelecimento.ToList());
        }

        // GET: Estabelecimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        public ActionResult Horario(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            List<Horario> lista = new List<Horario>();
            lista = estabelecimento.Horario.ToList();

            return View(lista.ToList());
        }

        // GET: Estabelecimentos/Create
        public ActionResult Create()
        {
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username");
            return View();
        }

        // POST: Estabelecimentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,CodigoPostal,Localidade,Rua,UtilizadorId,Estado")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Estabelecimento.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", estabelecimento.UtilizadorId);
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", estabelecimento.UtilizadorId);
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,CodigoPostal,Localidade,Rua,UtilizadorId,Estado")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilizadorId = new SelectList(db.Utilizador, "ID", "Username", estabelecimento.UtilizadorId);
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            db.Estabelecimento.Remove(estabelecimento);
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
