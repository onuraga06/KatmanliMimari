using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_Rep
{
   public interface IBaseRepository<T> where T :class,new()
    {
        DbSet<T> Set();
        List<T> GetList();
        T  Bul(int id);
        T  Bul(string id);
        IQueryable<T> GetAllList();
        void Add(T value);
        void Delete(T value);
        void Save();
    }
}
