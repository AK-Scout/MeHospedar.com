using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeHospedar.Areas.Usuarios.Models;
using MeHospedar.Contexts;
using MeHospedar.Models;

namespace MeHospedar.Areas.Usuarios.Controllers
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
        public ActionResult Create(Guid id)
        {
            Viajante viajante = new Viajante();
            viajante.ViajanteId = id;
            return View(viajante);
        }

        // POST: Viajantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajanteId,Nome,Sobrenome,Telefone,Foto")] Viajante viajante, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                    
                db.Viajantes.Add(viajante);
                db.SaveChanges();

                   if (file != null)
             {
                 String[] strName = file.FileName.Split('.');
                 String strExt = strName[strName.Count() - 1];
                 string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Imagens/"), viajante.ViajanteId, strExt); //salvo com o id do usuário Ex. 11.jpg
                 String pathBase = String.Format("/Imagens/{0}.{1}", viajante.ViajanteId, strExt);
                 file.SaveAs(pathSave);
                 viajante.Foto = pathBase;
                 db.SaveChanges();
             }


                return RedirectToAction("Index", "Home");
            }

            return View(viajante);
        }

        // GET: Viajantes/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajante viajante = db.Viajantes.Find(id);
            if (viajante == null)
            {
                // return HttpNotFound();
                return RedirectToAction("Create", "Viajantes", new {Area = "Usuarios", id = id });
            }
            else
            {
                return View(viajante);
            }
            
        }

        // POST: Viajantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajanteId,Nome,Sobrenome,Telefone,Foto")] Viajante viajante, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajante).State = EntityState.Modified;
                db.SaveChanges();
                if (file != null)
                {
                    if (viajante.Foto != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/" + viajante.Foto)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/" + viajante.Foto));
                        }
                    }
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Imagens/"), viajante.ViajanteId, strExt);
                    String pathBase = String.Format("/Imagens/{0}.{1}", viajante.ViajanteId, strExt);
                    file.SaveAs(pathSave);
                    viajante.Foto = pathBase;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
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
