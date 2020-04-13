using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeHospedar.Areas.Hoteis.Models;
using MeHospedar.Contexts;

namespace MeHospedar.Areas.Hoteis.Controllers
{
    public class HoteisController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Hoteis/Hoteis
        public ActionResult Index()
        {
            var hoteis = db.Hoteis.Include(h => h.Endereco).Include(h => h.Estrutura).Include(h => h.Idioma);
            return View(hoteis.ToList());
        }

        // GET: Hoteis/Hoteis/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hoteis.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hoteis/Hoteis/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Rua");
            ViewBag.EstruturaId = new SelectList(db.Estruturas, "EstruturaId", "EstruturaId");
            ViewBag.IdiomaId = new SelectList(db.Idiomas, "IdiomaId", "Descricao");
            return View();
        }

        // POST: Hoteis/Hoteis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelId,Nome,NomeContato,Telefone,Estrelas,EnderecoId,EstruturaId,IdiomaId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                
                hotel.HotelId = Guid.NewGuid();
                db.Hoteis.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Rua", hotel.EnderecoId);
            ViewBag.EstruturaId = new SelectList(db.Estruturas, "EstruturaId", "EstruturaId", hotel.EstruturaId);
            ViewBag.IdiomaId = new SelectList(db.Idiomas, "IdiomaId", "Descricao", hotel.IdiomaId);
            return View(hotel);
        }

        // GET: Hoteis/Hoteis/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hoteis.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Rua", hotel.EnderecoId);
            ViewBag.EstruturaId = new SelectList(db.Estruturas, "EstruturaId", "EstruturaId", hotel.EstruturaId);
            ViewBag.IdiomaId = new SelectList(db.Idiomas, "IdiomaId", "Descricao", hotel.IdiomaId);
            return View(hotel);
        }

        // POST: Hoteis/Hoteis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelId,Nome,NomeContato,Telefone,Estrelas,EnderecoId,EstruturaId,IdiomaId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Rua", hotel.EnderecoId);
            ViewBag.EstruturaId = new SelectList(db.Estruturas, "EstruturaId", "EstruturaId", hotel.EstruturaId);
            ViewBag.IdiomaId = new SelectList(db.Idiomas, "IdiomaId", "Descricao", hotel.IdiomaId);
            return View(hotel);
        }

        // GET: Hoteis/Hoteis/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hoteis.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hoteis/Hoteis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Hotel hotel = db.Hoteis.Find(id);
            db.Hoteis.Remove(hotel);
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
