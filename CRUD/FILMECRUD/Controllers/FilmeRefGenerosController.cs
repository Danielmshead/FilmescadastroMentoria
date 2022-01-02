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
    [CustomAuthorize (Roles = "admin")]
    public class FilmeRefGenerosController : Controller
    {
        private FilmesEntities db = new FilmesEntities();

        // GET: FilmeRefGeneros
        public ActionResult Index()
        {
            return View(db.FilmeRefGenero.ToList());
        }

        // GET: FilmeRefGeneros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeRefGenero filmeRefGenero = db.FilmeRefGenero.Find(id);
            if (filmeRefGenero == null)
            {
                return HttpNotFound();
            }
            return View(filmeRefGenero);
        }

        // GET: FilmeRefGeneros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmeRefGeneros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeRefGeneroID,FilmeRefGeneroName")] FilmeRefGenero filmeRefGenero)
        {
            if (ModelState.IsValid)
            {
                db.FilmeRefGenero.Add(filmeRefGenero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmeRefGenero);
        }

        // GET: FilmeRefGeneros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeRefGenero filmeRefGenero = db.FilmeRefGenero.Find(id);
            if (filmeRefGenero == null)
            {
                return HttpNotFound();
            }
            return View(filmeRefGenero);
        }

        // POST: FilmeRefGeneros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeRefGeneroID,FilmeRefGeneroName")] FilmeRefGenero filmeRefGenero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmeRefGenero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmeRefGenero);
        }

        // GET: FilmeRefGeneros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeRefGenero filmeRefGenero = db.FilmeRefGenero.Find(id);
            if (filmeRefGenero == null)
            {
                return HttpNotFound();
            }
            return View(filmeRefGenero);
        }

        // POST: FilmeRefGeneros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmeRefGenero filmeRefGenero = db.FilmeRefGenero.Find(id);
            db.FilmeRefGenero.Remove(filmeRefGenero);
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
