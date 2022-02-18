using Mimari_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanliMimari.Models
{
    public class SinifModel
    {
        public Sinif sinif { get; set; }
        public List<Sinif> sinifList { get; set; }
        public Ogrenci ogrenci { get; set; }
        public List<Ogrenci> ogrlist { get; set; }
        public IQueryable<SelectListItem> KademeListesi { get; set; }
        public IQueryable<SelectListItem> SubeListesi { get; set; }

    }
}