using Mimari_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatmanliMimari.Models
{
    public class SinifModel
    {
        public Sinif sinif { get; set; }
        public List<Sinif> sinifList { get; set; }
        public List<Ogrenci> ogrlist { get; set; }
    }
}