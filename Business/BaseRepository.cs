using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class BaseRepository<T> where T:class
    {
      MyContext db = new MyContext();

      public List<T> GetAll()
      {
          return db.Set<T>().ToList();
      }
      public T GetById(int id)
      {
          return db.Set<T>.Find(id);
      }
      public void Insert(T obj)
      {
          db.Set<T>().Add(obj);
          db.SaveChanges();
      }
      public void Delete(int id)
      {
          var obj = db.Set<T>.Find(id);
          db.Set<T>.Remove(obj);
          db.SaveChanges();
      }
      public void Update(T obj)
      {
          db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
          db.SaveChanges();
      }
    }
}
