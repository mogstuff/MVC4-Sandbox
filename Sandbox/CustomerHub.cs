using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using Sandbox.Models;
using Sandbox.DAL;
using System.Data.Entity;

namespace Sandbox
{
    public class CustomerHub : Hub 
    {
        private static List<Customer> Customers = new List<Customer>();
        private static SandBoxContext db = new SandBoxContext();
        private CustomerRepository _repo = new CustomerRepository();
        
        public IEnumerable<Customer> GetCustomers() 
        {
             var Customers = _repo.SelectAll();
             return Customers;
        }

        public void AddCustomer(Customer obj) 
        {
            _repo.Insert(obj);
            var Customers = _repo.SelectAll();
            Clients.All.updateCustomerList(Customers);
        }

        public void Send(String message)
        {
            // Call the addMessage methods on all clients
            //Clients.All.addMessage(message);
            Clients.All.addNewMessageToPage(message);
        }
     


        public override Task OnConnected()
        {
            // Send voting history to caller only so they can see an updated view of the votes 
            var Customers = _repo.SelectAll();
            Clients.Caller.getCustomersList(Customers);
            return base.OnConnected();
        }


    }
}