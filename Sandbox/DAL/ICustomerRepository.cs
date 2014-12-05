using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Models;

namespace Sandbox.DAL
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> SelectAll();
        Customer SelectByID(string id);
        void Insert(Customer obj);
        void Update(Customer obj);
        void Delete(string id);
        void Save();
    }
}
