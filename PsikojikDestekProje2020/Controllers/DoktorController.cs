using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsikojikDestekProje2020.Models.Entitys;
using System.Security;


namespace PsikojikDestekProje2020.Controllers
{
    public class DoktorController : Controller
    {
        PsikoProjeEntities1 db = new PsikoProjeEntities1();
        // GET: Doktor


        [Authorize]
        public ActionResult DoktorIndex()
        {

            var degerler = db.Doktor.ToList();
            return View(degerler);
        }

        public ActionResult Hastalarim(int id)
        {
            var hastalar = db.Recete.Where(x=>x.DoktorID==id).ToList();
            return View(hastalar);
        }

        public ActionResult HastaDetayGetir(int id)
        {
            var detaygetir = db.Hasta.Find(id);



            return View("HastaDetayGetir",detaygetir);
        }

        public ActionResult HastaDetayGuncelle(Hasta hst)
        {

            var detaygun = db.Hasta.Find(hst.HastaID);
            detaygun.HastaAdı = hst.HastaAdı;
            detaygun.HastaSoyadı = hst.HastaSoyadı;
            detaygun.HastaAdres = hst.HastaAdres;
            detaygun.HastaTelefon = hst.HastaTelefon;
            detaygun.HastaTC = hst.HastaTC;
            detaygun.HastaMail = hst.HastaMail;

            db.SaveChanges();
            return RedirectToAction("Hastalarim");
        }

        public ActionResult HastaRandevuDetay(int id )
        {
            var randetaygetir = db.Randevu.Find(id);
            List<SelectListItem> hastadeger = (from i in db.Hasta.ToList()

                                               select new SelectListItem
                                               {

                                                   Text = i.HastaAdı + "" + i.HastaSoyadı,
                                                   Value = i.HastaID.ToString()
                                               }).ToList();

            ViewBag.hastadgr = hastadeger;

            List<SelectListItem> doktordeger = (from i in db.Doktor.ToList()

                                                select new SelectListItem
                                                {

                                                    Text = i.DoktorAdı + "" + i.SoktorSoyadı,
                                                    Value = i.Doktorid.ToString()
                                                }

                                              ).ToList();
            ViewBag.doktordgr = doktordeger;

           
           

            return View("HastaRandevuDetay",randetaygetir);
        }

        public ActionResult RandevuDetayGuncelle(Randevu rndv)
        {
            var randevu = db.Randevu.Find(rndv.RandevuID);
            randevu.Tarih = rndv.Tarih;

            var hasta = db.Hasta.Where(h => h.HastaID == rndv.Hasta.HastaID).FirstOrDefault();
            var doktor = db.Doktor.Where(d => d.Doktorid == rndv.Doktor.Doktorid).FirstOrDefault();

            randevu.DoktorID = doktor.Doktorid;
            randevu.HastaID = hasta.HastaID;
            db.SaveChanges();

            return RedirectToAction("Hastalarim");
        }


        public ActionResult HastaRandevuListele(int id)
        {
            var randevuliste = db.Randevu.Where(x => x.DoktorID == id).ToList();

            return View(randevuliste);
        }

        public ActionResult HastaReceteDetayGetir(int id)
        {

            var recete = db.Recete.Find(id);

            List<SelectListItem> hastadeger = (from i in db.Hasta.ToList()

                                               select new SelectListItem
                                               {

                                                   Text = i.HastaAdı + "" + i.HastaSoyadı,
                                                   Value = i.HastaID.ToString()
                                               }).ToList();

            ViewBag.hastadgr = hastadeger;

            List<SelectListItem> doktordeger = (from i in db.Doktor.ToList()

                                                select new SelectListItem
                                                {

                                                    Text = i.DoktorAdı + "" + i.SoktorSoyadı,
                                                    Value = i.Doktorid.ToString()
                                                }

                                              ).ToList();
            ViewBag.doktordgr = doktordeger;


            return View("HastaReceteDetayGetir",recete);
        }

        public ActionResult HastaReceteGuncelle(Recete rct)
        {
            var recete = db.Recete.Find(rct.ReceteID);
            recete.IlacAdi = rct.IlacAdi;
            recete.Doz = rct.Doz;
            recete.KullanimTalimati = rct.KullanimTalimati;


            var hasta = db.Hasta.Where(h => h.HastaID == rct.Hasta.HastaID).FirstOrDefault();
            var doktor = db.Doktor.Where(d => d.Doktorid == rct.Doktor.Doktorid).FirstOrDefault();

            recete.DoktorID = doktor.Doktorid;
            recete.HastaID = hasta.HastaID;
            db.SaveChanges();


            return RedirectToAction("DoktorIndex");
        }

        public ActionResult HastaReceteListele(int id)
        {
            var receteliste = db.Recete.Where(x => x.Hasta.HastaID == id).ToList();

            return View(receteliste);
        }

        public ActionResult HastaNotDetayGetir(int id)
        {
            var not = db.HastaNot.Find(id);

            List<SelectListItem> hastadeger = (from i in db.Hasta.ToList()

                                               select new SelectListItem
                                               {

                                                   Text = i.HastaAdı + "" + i.HastaSoyadı,
                                                   Value = i.HastaID.ToString()
                                               }).ToList();

            ViewBag.hastadgr = hastadeger;

            List<SelectListItem> doktordeger = (from i in db.Doktor.ToList()

                                                select new SelectListItem
                                                {

                                                    Text = i.DoktorAdı + "" + i.SoktorSoyadı,
                                                    Value = i.Doktorid.ToString()
                                                }

                                              ).ToList();
            ViewBag.doktordgr = doktordeger;



            return View("HastaNotDetayGetir", not);
        }

        public ActionResult HastaNotGuncelle(HastaNot hstnot)
        {
            var not = db.HastaNot.Find(hstnot.HastaNotID);

            not.Notlar = hstnot.Notlar;

            var hasta = db.Hasta.Where(h => h.HastaID == hstnot.Hasta.HastaID).FirstOrDefault();
            var doktor = db.Doktor.Where(d => d.Doktorid == hstnot.Doktor.Doktorid).FirstOrDefault();

            not.DoktorID = doktor.Doktorid;
            not.HastaID = hasta.HastaID;
            db.SaveChanges();



            return RedirectToAction("DoktorIndex");
        }
        
        public ActionResult NotListe(int id)
        {
            //hastanın id sine göre alınan tüm notları listeliyor

            var liste = db.HastaNot.Where(x => x.Hasta.HastaID == id).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult NotEkle()
        {

            

            List<SelectListItem> hastadeger = (from i in db.Hasta.ToList()

                                               select new SelectListItem
                                               {

                                                   Text = i.HastaAdı + "" + i.HastaSoyadı,
                                                   Value = i.HastaID.ToString()
                                               }).ToList();

            ViewBag.hastadgr = hastadeger;

            List<SelectListItem> doktordeger = (from i in db.Doktor.ToList()

                                                select new SelectListItem
                                                {

                                                    Text = i.DoktorAdı + "" + i.SoktorSoyadı,
                                                    Value = i.Doktorid.ToString()
                                                }

                                              ).ToList();
            ViewBag.doktordgr = doktordeger;

            return View();
        }


        [HttpPost]
        public ActionResult NotEkle(HastaNot hn)
        {
            var hasta = db.Hasta.Where(h => h.HastaID == hn.Hasta.HastaID).FirstOrDefault();
            hn.Hasta = hasta;
            var doktor = db.Doktor.Where(d => d.Doktorid == hn.Doktor.Doktorid).FirstOrDefault();
            hn.Doktor = doktor;

            db.HastaNot.Add(hn);
            db.SaveChanges();

            return RedirectToAction("NotEkle");

        }
        public ActionResult RandevularimiListele(int id)
        {
            var randevularim = db.Randevu.Where(x => x.DoktorID == id).ToList();

            return View(randevularim);
        }

    }
}