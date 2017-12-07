
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using DAL;

namespace Business
{
    public class BaseRepository<T> where T : class
    {
        MyContext db = MyContext.db;
        public BaseRepository()
        {
            if (MyContext.db == null) MyContext.db = new MyContext();
        }

        public List<T> GetAll()
        {
            if (MyContext.db == null) MyContext.db = new MyContext();
            List<T> liste = db.Set<T>().ToList();
            return liste;
        }
        public List<T> Search(string value)
        {
            if (MyContext.db == null) MyContext.db = new MyContext();
            List<T> liste = db.Set<T>().ToList();
            return liste;
        }

        public void DetachList(List<T> liste)
        {
           liste.ForEach(group => db.Entry(group).State = System.Data.Entity.EntityState.Detached);
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.Set<T>().Find(id);
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
