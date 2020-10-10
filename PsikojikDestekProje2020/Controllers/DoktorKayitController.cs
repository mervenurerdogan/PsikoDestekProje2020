using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsikojikDestekProje2020.Models.Entitys;

namespace PsikojikDestekProje2020.Controllers
{
    public class DoktorKayitController : Controller
    {

        PsikoProjeEntities1 db = new PsikoProjeEntities1();
        // GET: DoktorKayit
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoktorKayitOl()
        {


            return View();
        }

        [HttpPost]
        public ActionResult DoktorKayitOl(Doktor d)
        {


            if (!ModelState.IsValid)
            {
                return View("DoktorKayitOl");
            }

            db.Doktor.Add(d);
            db.SaveChanges();
            ViewBag.BasariliKayit = "Kayıt İşlemi Başarılı";
            return RedirectToAction("DoktorGirisYap","DoktorLogin");


            
        }
    }
}