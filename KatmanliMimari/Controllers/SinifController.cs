using Katmanli_Business;
using Katmanli_Rep;
using KatmanliMimari.Models;
using Mimari_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanliMimari.Controllers
{
    public class SinifController : Controller

    {
        
        Repository.SinifRepository sp = new Repository.SinifRepository();
        SinifModel model = new SinifModel();
        // GET: Sinif
        public ActionResult Index(string name)
        {
            if (name == null)//Eger Name nulll ise bos bırak//Arama-Search Kısmı
            {
                name = "";
            }
            model.sinifList = sp.GetAllList().Where(x => x.Sube.Contains(name)).ToList();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.sinif = sp.Bul(id);
            return View(model);

        }
        public ActionResult Sil(int id)
        {
            Sinif s = sp.Bul(id);
            sp.Delete(s);
            sp.Save();
            return View();
        }
        public ActionResult Guncel(int id)
        {
            model.sinif = sp.Bul(id);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncel(int id,SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Sinif s = sp.Bul(id);
                s.SinifID = sm.sinif.SinifID;
                s.Sube = sm.sinif.Sube;
                s.SinifMevcudu = sm.sinif.SinifMevcudu;
                s.Kademe = sm.sinif.Kademe;
                sp.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Sinif s = new Sinif();
                s.Sube = sm.sinif.Sube;
                s.Kademe = sm.sinif.Kademe;
                if(sp.GetList().Where(x=> x.Sube==sm.sinif.Sube && x.Kademe == sm.sinif.Kademe).Count() == null)
                {
                    s.SinifMevcudu = 0;
                }
                else
                {
                    s.SinifMevcudu = sm.sinif.SinifMevcudu;
                }
                sp.Add(s);
                sp.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sec()
        {


            model.sinifList = sp.GetAllList().Where(x => x.Sube.Contains("A")).ToList();
            return View(model);
        }
    }
}