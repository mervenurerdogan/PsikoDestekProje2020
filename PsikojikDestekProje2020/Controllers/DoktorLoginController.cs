using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PsikojikDestekProje2020.Models.Entitys;
using System.Web.Security;


namespace PsikojikDestekProje2020.Controllers
{
    public class DoktorLoginController : Controller
    {
        PsikoProjeEntities1 db = new PsikoProjeEntities1();
        // GET: DoktorLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoktorGirisYap()
        {


            return View();
        }

        [HttpPost]
        public ActionResult DoktorGirisYap(Doktor dktr)
        {
            var bilgiler = db.Doktor.FirstOrDefault(x => x.DoktorMail == dktr.DoktorMail && x.DoktorSifre == dktr.DoktorSifre);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.DoktorMail, false);

                Session["Doktorid"] = bilgiler.Doktorid.ToString();
                Session["DoktorAdı"] = bilgiler.DoktorAdı.ToString();
                Session["SoktorSoyadı"] = bilgiler.SoktorSoyadı.ToString();
                Session["DoktorMail"] = bilgiler.DoktorMail.ToString();
                Session["DoktorSifre"] = bilgiler.DoktorSifre.ToString();
                
                return RedirectToAction("DoktorIndex", "Doktor");

            }

            else
            {
                ViewBag.HataMesaji = "Hatalı Mail veya Şifre !!!";
                return View();
            }

            
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("DoktorGirisYap");
            
        }
    }
}