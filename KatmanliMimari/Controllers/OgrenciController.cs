﻿using Katmanli_Business;
using KatmanliMimari.Models;
using Mimari_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanliMimari.Controllers
{
    public class OgrenciController : Controller
    {
        Repository.OgrenciRepository rep = new Repository.OgrenciRepository();
        Repository.SinifRepository sep = new Repository.SinifRepository();
        SinifModel model = new SinifModel();
        public ActionResult Index()
        {
            model.ogrlist = rep.GetList();
            
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.ogrenci = rep.Bul(id);
            return View(model);

        }
        public ActionResult Ekle()
        {
            model.SubeListesi = sep.GetAllList().Select(x => new SelectListItem
            {
                Text = x.Sube,
                Value = x.Sube
            }).Distinct();//VERİLERİN TEKRANINI ENGELLER
            model.KademeListesi = sep.GetAllList().Select(x => new SelectListItem
            {
                Text = x.Kademe.ToString(),
                Value = x.Kademe.ToString()
            }).Distinct();
            return View(model);

        }
        [HttpPost]
        public ActionResult Ekle(SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Ogrenci o = new Ogrenci();
                o.OgrenciAd = sm.ogrenci.OgrenciAd;
                o.OgrenciSoyad = sm.ogrenci.OgrenciSoyad;
                o.Kademe = sm.sinif.Kademe;
                o.Sube = sm.sinif.Sube;
                o.Adres = sm.ogrenci.Adres;
                rep.Add(o);
                rep.Save();
                model.sinif = sep.Set().FirstOrDefault(x => x.Sube == sm.sinif.Sube && x.Kademe == sm.sinif.Kademe);
                model.sinif.SinifMevcudu += 1;
                sep.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            Ogrenci o = rep.Bul(id);
          
            model.sinif = sep.Set().FirstOrDefault(x => x.Sube == o.Sube && x.Kademe == o.Kademe);
            rep.Delete(o);
            rep.Save();
            model.sinif.SinifMevcudu -= 1;
            sep.Save();
            return RedirectToAction("Index");

        }
    }
}