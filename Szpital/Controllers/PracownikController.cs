using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Szpital.Models;

namespace Szpital.Controllers
{
    public class PracownikController : Controller
    {
        private SzpitalContext db = new SzpitalContext();

        // GET: Pracownik
        public ActionResult Index()
        {
            return View(db.Pracowniks.ToList());
        }

        // GET: Pracownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracowniks.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracownik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pracownik/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracownikID,Imie,Nazwisko,Oddzial,Stopien")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracowniks.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pracownik);
        }

        // GET: Pracownik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracowniks.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracownikID,Imie,Nazwisko,Oddzial,Stopien")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pracownik);
        }

        // GET: Pracownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracowniks.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracowniks.Find(id);
            db.Pracowniks.Remove(pracownik);
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
