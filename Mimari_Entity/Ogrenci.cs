using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari_Entity
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        [Required]
        public string OgrenciAd { get; set; }
        [Required]
        public string OgrenciSoyad { get; set; }
        [StringLength(200)]
        public string Adres { get; set; }
        public DateTime Yas { get; set; }
        [ForeignKey("Sinif")]
        public int Kademe { get; set; }
        //public int SinifID { get; set; }
        public Sinif Sinif { get; set; }
    }
}
