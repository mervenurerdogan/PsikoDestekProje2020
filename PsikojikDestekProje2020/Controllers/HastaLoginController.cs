using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PsikojikDestekProje2020.Models.Entitys;
namespace PsikojikDestekProje2020.Controllers
{
    public class HastaLoginController : Controller
    {
        // GET: HastaLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HastaGirisYap()
        {

            return View();
        }


        [HttpPost]
        public ActionResult HastaGirisYap(Hasta hst)
        {

            return View();
        }

    }
}