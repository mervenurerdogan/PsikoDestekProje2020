using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsikojikDestekProje2020.Models.Entitys;

namespace PsikojikDestekProje2020.Controllers
{
    public class DoktorProfilIslemleriController : Controller
    {

        PsikoProjeEntities1 db = new PsikoProjeEntities1();
        // GET: DoktorProfilIslemleri
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult DoktorProfilimGetir()
        {
            var dktrMail = (string)Session["DoktorMail"];

            var degerler = db.Doktor.FirstOrDefault(x => x.DoktorMail == dktrMail);

            List<SelectListItem> dktbolum = (from i in db.Bolum.ToList()

                                             select new SelectListItem

                                             {
                                                 Text = i.BolumAdi,
                                                 Value = i.BolumID.ToString()

                                             }

                                       ).ToList();
            ViewBag.doktorbolum = dktbolum;

            return View(degerler);
        }




        public ActionResult DoktorProfilGuncelle(Doktor d)
        {
            if (!ModelState.IsValid)
            {
                return View("DoktorProfilimGetir");

            }

            var kullanici = (string)Session["DoktorMail"];
            //string olrak maili taşıycaz
            var doktor = db.Doktor.FirstOrDefault(x => x.DoktorMail == kullanici);
            doktor.DoktorSifre = d.DoktorSifre; ;
            doktor.DoktorAdı = d.DoktorAdı;
            doktor.SoktorSoyadı = d.SoktorSoyadı;
            doktor.DoktorMail = d.DoktorMail;
            doktor.DoktorUnvan = d.DoktorUnvan;
         


            var d1 = db.Bolum.Where(x => x.BolumID == d.Bolum.BolumID).FirstOrDefault();
            d.Bolum = d1;

            doktor.BolumID = d1.BolumID;
         

            db.SaveChanges();



            return RedirectToAction("DoktorProfilimGetir");
        }


   
        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("GirisYap", "Login");
        //}


    }
}