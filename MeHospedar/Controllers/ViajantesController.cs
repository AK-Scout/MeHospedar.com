using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeHospedar.Contexts;
using MeHospedar.Models;

namespace MeHospedar.Controllers
{
    public class ViajantesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Viajantes
        public ActionResult Index()
        {
            return View(db.Viajantes.ToList());
        }

        // GET: Viajantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajante viajante = db.Viajantes.Find(id);
            if (viajante == null)
            {
                return HttpNotFound();
            }
            return View(viajante);
        }

        // GET: Viajantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viajantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Telefone")] Viajante viajante)
        {
            if (ModelState.IsValid)
            {
                db.Viajantes.Add(viajante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajante);
        }

        // GET: Viajantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajante viajante = db.Viajantes.Find(id);
            if (viajante == null)
            {
                return HttpNotFound();
            }
            return View(viajante);
        }

        // POST: Viajantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Telefone")] Viajante viajante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viajante);
        }

        // GET: Viajantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajante viajante = db.Viajantes.Find(id);
            if (viajante == null)
            {
                return HttpNotFound();
            }
            return View(viajante);
        }

        // POST: Viajantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajante viajante = db.Viajantes.Find(id);
            db.Viajantes.Remove(viajante);
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
