using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sandbox.Models;
using System.Data;
using System.Data.Entity;

namespace Sandbox.DAL
{
    public class CustomerRepository
    {
        private SandBoxContext db = null;

        public CustomerRepository() 
        {
            this.db = new SandBoxContext();
        }

        public CustomerRepository(SandBoxContext db)
        {
            this.db = db;
        }

        public IEnumerable<Customer> SelectAll()
        {
            return db.Customers.ToList();
        }

        public Customer SelectByID(string id)
        {
            return db.Customers.Find(id);
        }

        public void Insert(Customer obj)
        {
            db.Customers.Add(obj);
        }

        public void Update(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Customer existing = db.Customers.Find(id);
            db.Customers.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}