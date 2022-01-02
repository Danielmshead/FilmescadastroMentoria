using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FILMECRUD.Models;

namespace FILMECRUD.Controllers
{
    [CustomAuthorize(Roles = "admin, usuario")]
    public class FilmeDetalhesController : Controller
    {
        private FilmesEntities db = new FilmesEntities();

        // GET: FilmeDetalhes
        public ActionResult Index()
        {
            var filmeDetalhe = db.FilmeDetalhe.Include(f => f.FilmeRefGenero);
            return View(filmeDetalhe.ToList());
        }

        // GET: FilmeDetalhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeDetalhe filmeDetalhe = db.FilmeDetalhe.Find(id);
            if (filmeDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(filmeDetalhe);
        }

        // GET: FilmeDetalhes/Create
        public ActionResult Create()
        {
            ViewBag.FilmeGeneroID = new SelectList(db.FilmeRefGenero, "FilmeRefGeneroID", "FilmeRefGeneroName");
            return View();
        }

        // POST: FilmeDetalhes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeID,FilmeDescricao,FilmeGeneroID,FilmeNome")] FilmeDetalhe filmeDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.FilmeDetalhe.Add(filmeDetalhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeGeneroID = new SelectList(db.FilmeRefGenero, "FilmeRefGeneroID", "FilmeRefGeneroName", filmeDetalhe.FilmeGeneroID);
            return View(filmeDetalhe);
        }

        // GET: FilmeDetalhes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeDetalhe filmeDetalhe = db.FilmeDetalhe.Find(id);
            if (filmeDetalhe == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeGeneroID = new SelectList(db.FilmeRefGenero, "FilmeRefGeneroID", "FilmeRefGeneroName", filmeDetalhe.FilmeGeneroID);
            return View(filmeDetalhe);
        }

        // POST: FilmeDetalhes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeID,FilmeDescricao,FilmeGeneroID,FilmeNome")] FilmeDetalhe filmeDetalhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmeDetalhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeGeneroID = new SelectList(db.FilmeRefGenero, "FilmeRefGeneroID", "FilmeRefGeneroName", filmeDetalhe.FilmeGeneroID);
            return View(filmeDetalhe);
        }

        // GET: FilmeDetalhes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeDetalhe filmeDetalhe = db.FilmeDetalhe.Find(id);
            if (filmeDetalhe == null)
            {
                return HttpNotFound();
            }
            return View(filmeDetalhe);
        }

        // POST: FilmeDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmeDetalhe filmeDetalhe = db.FilmeDetalhe.Find(id);
            db.FilmeDetalhe.Remove(filmeDetalhe);
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
