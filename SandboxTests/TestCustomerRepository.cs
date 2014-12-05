using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.DAL;
using Sandbox.Models;

namespace SandboxTests
{
    class TestCustomerRepository : ICustomerRepository
    {
        private List<Customer> data = new List<Customer>();

        public IEnumerable<Customer> SelectAll()
        {
            return data;
        }

        public Customer SelectByID(int id)
        {
            return data.Find(m => m.CustomerId == id);
        }

        public void Insert(Customer obj)
        {
            data.Add(obj);
        }

        public void Update(Customer obj)
        {
            Customer existing = data.Find(m => m.CustomerId == obj.CustomerId);
            existing = obj;
        }

        public void Delete(int id)
        {
            Customer existing = data.Find(m => m.CustomerId == id);
            data.Remove(existing);
        }

        public void Save()
        {
            //nothing here
        }
    }
}
