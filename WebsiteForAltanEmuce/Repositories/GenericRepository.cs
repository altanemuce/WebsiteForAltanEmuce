using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebsiteForAltanEmuce.Models.EntityFramework;

namespace WebsiteForAltanEmuce.Repositories
{
    public class GenericRepository <T> where T:class,new()
    {
        CreativeWebsiteForAltanEmuceEntities db = new CreativeWebsiteForAltanEmuceEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void  Add(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void Delete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T p)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
}