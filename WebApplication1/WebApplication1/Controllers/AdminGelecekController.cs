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
    public class AdminGelecekController : Controller
    {
        private VeriTabani db = new VeriTabani();


        public ActionResult Index()
        {
            return View(db.Geleceks.ToList());
        }

     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gelecek gelecek = db.Geleceks.Find(id);
            if (gelecek == null)
            {
                return HttpNotFound();
            }
            return View(gelecek);
        }




    
        public ActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult Create(Gelecek gelecek, HttpPostedFileBase gelecek_resim)
        {

            if (ModelState.IsValid)
            {

                if (gelecek_resim != null)
                {
                    WebImage img = new WebImage(gelecek_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(gelecek_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;

                    img.Save("~/Content/img/gelecek/" + yenifoto);
                    gelecek.gelecek_resim = yenifoto;



                }
                db.Geleceks.Add(gelecek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gelecek);
        }

       




        public ActionResult Edit(int? id)
        {
            var geleceks = db.Geleceks.Where(v => v.gelecek_id == id).SingleOrDefault();

            if (geleceks == null)
            {
                return HttpNotFound();
            }
          
            return View(geleceks);
        }


        [HttpPost]
        
        public ActionResult Edit(int id ,HttpPostedFileBase gelecek_resim, Gelecek gelecek)
        {
            try
            {
                var geleceks = db.Geleceks.Where(v => v.gelecek_id == id).SingleOrDefault();

                if (gelecek_resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(geleceks.gelecek_resim)))
                    {
                        System.IO.File.Delete(Server.MapPath(geleceks.gelecek_resim));
                    }

                    WebImage img = new WebImage(gelecek_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(gelecek_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;

                    img.Save("~/Content/img/gelecek/" + yenifoto);
                    geleceks.gelecek_resim = yenifoto;
                    geleceks.gelecek_adi = gelecek.gelecek_adi;
                 
                    geleceks.gelecek_fragman = gelecek.gelecek_fragman;
                    geleceks.gelecek_konu = gelecek.gelecek_konu;
              
                    geleceks.gelecek_tarih = gelecek.gelecek_tarih;


                    db.SaveChanges();


                }


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: AdminGelecek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gelecek gelecek = db.Geleceks.Find(id);
            if (gelecek == null)
            {
                return HttpNotFound();
            }
            return View(gelecek);
        }

        // POST: AdminGelecek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gelecek gelecek = db.Geleceks.Find(id);
            db.Geleceks.Remove(gelecek);
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
