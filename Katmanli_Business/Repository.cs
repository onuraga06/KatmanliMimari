using Katmanli_Rep;
using Mimari_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_Business
{// Business Layer : İş Kuralları yazılır, karar mekanizmasıdır
  public  class Repository
    {
        public class OgrenciRepository:BaseRepository<Ogrenci>
        {

        }
        public class SinifRepository : BaseRepository<Sinif>
        {

        }

    }
}
