using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sandbox.Models;
using System.Data;
using System.Data.Entity;

namespace Sandbox.DAL
{
  
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private SandBoxContext db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new SandBoxContext();
            table = db.Set<T>();
        }

        public GenericRepository(SandBoxContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectByID(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }



}