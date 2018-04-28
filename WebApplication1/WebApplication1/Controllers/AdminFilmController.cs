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
    public class AdminFilmController : Controller
    {
        private VeriTabani db = new VeriTabani();

        // GET: AdminFilm
        public ActionResult Index()
        {
            var films = db.Films.Include(f => f.Kategori);
            return View(films.ToList());
        }

        // GET: AdminFilm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: AdminFilm/Create
        public ActionResult Create()
        {
            ViewBag.film_kategori_id = new SelectList(db.Kategoris, "kategori_id", "kategori_adi");
            return View();
        }



        [HttpPost]
        public ActionResult Create(Film film,HttpPostedFileBase film_resim)
        {
            if(ModelState.IsValid)
            {

               if(film_resim != null)
                {
                    WebImage img = new WebImage(film_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(film_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    
                    img.Save("~/Content/img/film/"+yenifoto);                   
                    film.film_resim = yenifoto; 
                    
                     
                   
                }
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
               
               return View(film); 
          
  
        }







        public ActionResult Edit(int id)
        {
            var films = db.Films.Where(v => v.film_id == id).SingleOrDefault();

            if (films == null)
            {
                return HttpNotFound();
            }
            ViewBag.film_kategori_id = new SelectList(db.Kategoris, "kategori_id", "kategori_adi", films.film_kategori_id);
            return View(films);
        }



        [HttpPost]
        public ActionResult Edit(int id,HttpPostedFileBase film_resim, Film film)
        {
            try
            {
                var films = db.Films.Where(v => v.film_id == id).SingleOrDefault();

                if(film_resim != null)
                {
                    if(System.IO.File.Exists(Server.MapPath(films.film_resim)))
                    {
                        System.IO.File.Delete(Server.MapPath(films.film_resim));    
                    }

                    WebImage img = new WebImage(film_resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(film_resim.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;

                    img.Save("~/Content/img/film/" + yenifoto);
                    films.film_resim = yenifoto;
                    films.film_adi = film.film_adi;
                    films.film_kategori_id = film.film_kategori_id;
                    films.film_fragman = film.film_fragman;
                    films.film_konu = film.film_konu;
                    films.film_puan = film.film_puan;
                    films.film_yil = film.film_yil;


                    db.SaveChanges();


                }


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
             
        }

        






        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
