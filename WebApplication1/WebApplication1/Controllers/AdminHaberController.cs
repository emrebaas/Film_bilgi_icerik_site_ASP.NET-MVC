using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminHaberController : Controller
    {
        private VeriTabani db = new VeriTabani();

        // GET: AdminHaber
        public ActionResult Index()
        {
            return View(db.Habers.ToList());
        }
        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Habers.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // GET: AdminHaber/Create
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Haber haber, HttpPostedFileBase haber_resim)
        {
            if (ModelState.IsValid)
            {

                if (haber_resim != null)
                {
                    WebImage img = new WebImage(haber_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(haber_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;

                    img.Save("~/Content/img/haber/" + yenifoto);
                    haber.haber_resim = yenifoto;



                }
                db.Habers.Add(haber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(haber);
        }

        // GET: AdminHaber/Edit/5
        public ActionResult Edit(int id)
        {
            var habers = db.Habers.Where(v => v.haber_id == id).SingleOrDefault();

            if (habers == null)
            {
                return HttpNotFound();
            }

            return View(habers);
        }

  
        [HttpPost]
        public ActionResult Edit(Haber haber,int id, HttpPostedFileBase haber_resim)
        {
            try
            {
                var habers = db.Habers.Where(v => v.haber_id == id).SingleOrDefault();

                if (haber_resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(habers.haber_resim)))
                    {
                        System.IO.File.Delete(Server.MapPath(habers.haber_resim));
                    }

                    WebImage img = new WebImage(haber_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(haber_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;

                    img.Save("~/Content/img/haber/" + yenifoto);

                    habers.haber_resim = yenifoto;
                    habers.haber_baslik = habers.haber_baslik;
                    habers.haber_aciklama = habers.haber_aciklama;

                    


                    db.SaveChanges();


                }


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: AdminHaber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Habers.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // POST: AdminHaber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Haber haber = db.Habers.Find(id);
            db.Habers.Remove(haber);
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
