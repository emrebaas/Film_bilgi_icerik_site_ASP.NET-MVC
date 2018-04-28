using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Kullanıcı uye)
        {
            VeriTabani vt = new VeriTabani();
            var giris = vt.Kullanıcı.Where(u => u.kullaniciadi == uye.kullaniciadi).SingleOrDefault();
            if (giris.kullaniciadi == uye.kullaniciadi && giris.sifre==uye.sifre)
            {
                Session["kullaniciadi"] = giris.kullaniciadi;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                  return View();
            }
          
        }

  


        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Aksiyon()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 1).ToList();
            return View(filmlistele);
        }


        public ActionResult Animasyon()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 2).ToList();
            return View(filmlistele);
        }


        public ActionResult Bilimkurgu()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 3).ToList();
            return View(filmlistele);
        }



        public ActionResult Dram()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 4).ToList();
            return View(filmlistele);
        }


        public ActionResult Fantastik()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 5).ToList();
            return View(filmlistele);
        }


        public ActionResult Komedi()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 6).ToList();
            return View(filmlistele);
        }


        public ActionResult Korku()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 7).ToList();
            return View(filmlistele);
        }



        public ActionResult Macera()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 8).ToList();
            return View(filmlistele);
        }

        public ActionResult Romantik()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 9).ToList();
            return View(filmlistele);
        }


        public ActionResult Savas()
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_kategori_id == 10).ToList();
            return View(filmlistele);
        }


        public ActionResult Haber()
        {
            VeriTabani vt = new VeriTabani();

            List<Haber> filmlistele = vt.Habers.OrderByDescending(i => i.haber_id).ToList();
            return View(filmlistele);
        }


        public ActionResult Gelecek()
        {
            VeriTabani vt = new VeriTabani();

            List<Gelecek> filmlistele = vt.Geleceks.OrderByDescending(i => i.gelecek_adi).ToList();
            return View(filmlistele);
        }




        public ActionResult SonİkiHaber()
        {
            //Veritabanından yeni bir nesne oluşturuyoruz.
            VeriTabani db = new VeriTabani();

            //Veritabanından sorgulamayı Linq ile yapıyoruz.
            //Tarih sırasına göre son makaleleri OrderByDescending ile çekip Take ile de 5 tane almasını istiyoruz.
            List<Haber> haberliste = db.Habers.OrderByDescending(i => i.haber_id).Take(3).ToList();

            //Normal içeriklerde View döndürürken, burada ise PartialView döndürüyoruz.
            //Ayrıca makaleListe nesnesini de View'de kullanacağımız şekilde model olarak aktarıyoruz.
            return PartialView(haberliste);
        }


        public ActionResult SonİkiGelecek()
        {
            //Veritabanından yeni bir nesne oluşturuyoruz.
            VeriTabani db = new VeriTabani();

            //Veritabanından sorgulamayı Linq ile yapıyoruz.
            //Tarih sırasına göre son makaleleri OrderByDescending ile çekip Take ile de 5 tane almasını istiyoruz.
            List<Gelecek> gelecekfilmliste = db.Geleceks.OrderByDescending(i => i.gelecek_id).Take(3).ToList();

            //Normal içeriklerde View döndürürken, burada ise PartialView döndürüyoruz.
            //Ayrıca makaleListe nesnesini de View'de kullanacağımız şekilde model olarak aktarıyoruz.
            return PartialView(gelecekfilmliste);
        }


        ////////////////////////////////////////////////////////////////////////

        public ActionResult BesAksiyon()
        {
           
            VeriTabani db = new VeriTabani();

            
            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id==1).Take(5).ToList();

            return PartialView(filmlistele);
        }

        ////////////////////////////////////////////////////////////////////////

        public ActionResult BesAnimasyon()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 2).Take(5).ToList();

            return PartialView(filmlistele);
        }

        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesBilimkurgu()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 3).Take(5).ToList();

            return PartialView(filmlistele);
        }

        ////////////////////////////////////////////////////////////////////////

        public ActionResult BesDram()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 4).Take(5).ToList();

            return PartialView(filmlistele);
        }



        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesFantastik()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 5).Take(5).ToList();

            return PartialView(filmlistele);
        }




        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesKorku()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 6).Take(5).ToList();

            return PartialView(filmlistele);
        }




        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesKomedi()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 7).Take(5).ToList();

            return PartialView(filmlistele);
        }





        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesMacera()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 8).Take(5).ToList();

            return PartialView(filmlistele);
        }




        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesRomantik()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id == 9).Take(5).ToList();

            return PartialView(filmlistele);
        }




        ////////////////////////////////////////////////////////////////////////


        public ActionResult BesSavas()
        {

            VeriTabani db = new VeriTabani();


            List<Film> filmlistele = db.Films.OrderByDescending(i => i.film_id).Where(i => i.film_kategori_id ==10).Take(5).ToList();

            return PartialView(filmlistele);
        }


        public ActionResult FilmDetay (int id)
        {
            VeriTabani db = new VeriTabani();
            var film = db.Films.Where(i => i.film_id == id).SingleOrDefault();

            if(film==null)
            {
                return HttpNotFound();
            }
            return View(film);
        }





        ////////////////////////////////////////////////////////////////////////




        public ActionResult HaberDetay(int id)
        {
            VeriTabani db = new VeriTabani();
            var film = db.Habers.Where(i => i.haber_id == id).SingleOrDefault();

            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }


        ////////////////////////////////////////////////////////////////////////





        public ActionResult GelecekDetay(int id)
        {
            VeriTabani db = new VeriTabani();
            var film = db.Geleceks.Where(i => i.gelecek_id == id).SingleOrDefault();

            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }


        /////////////////////////////////////////////////////////////////////



        public ActionResult FilmAra(String Ara=null)
        {
            VeriTabani vt = new VeriTabani();

            List<Film> filmlistele = vt.Films.OrderByDescending(i => i.film_adi).Where(i => i.film_adi.Contains(Ara)).ToList();
            return View(filmlistele);
        }
    }
}