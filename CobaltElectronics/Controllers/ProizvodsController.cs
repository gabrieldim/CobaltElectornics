using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CobaltElectronics.Models;

namespace CobaltElectronics.Controllers
{
    public class ProizvodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proizvods
        public ActionResult Index()
        {
            return View(db.Proizvods.ToList());
        }

        // GET: Proizvods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: Proizvods/Create
        [Authorize(Roles ="Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImgURL,Ime,Proizvoditel,Cena,DaliNaZaliha,Opis")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvods.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(proizvod);
        }

        // GET: Proizvods/Edit/5
        [Authorize(Roles = "Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImgURL,Ime,Proizvoditel,Cena,DaliNaZaliha,Opis")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(proizvod);
        }

        // GET: Proizvods/Delete/5
        [Authorize(Roles = "Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvod proizvod = db.Proizvods.Find(id);
            db.Proizvods.Remove(proizvod);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
