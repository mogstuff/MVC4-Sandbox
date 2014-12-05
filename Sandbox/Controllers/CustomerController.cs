using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.DAL;
using Sandbox.Models;
using Microsoft.AspNet.SignalR;


namespace Sandbox.Controllers
{
    public class CustomerController : Controller
    {
        //private CustomerRepository repository = null;
        private IGenericRepository<Customer> repository = null;

        public CustomerController()
        {
            this.repository = new GenericRepository<Customer>();
        }

        public CustomerController(IGenericRepository<Customer> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            List<Customer> model = (List<Customer>)repository.SelectAll();
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Insert(Customer obj)
        {
            repository.Insert(obj);
            repository.Save();
            string message = "New Customer added " + obj.CompanyName + " "  +  DateTime.Now;
            var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.addNewMessageToPage(message);
            List<Customer> model = (List<Customer>)repository.SelectAll();
            context.Clients.All.updateCustomerList(model);
            return View();
        }

        public ActionResult Edit(int id)
        {
           // Customer existing = repository.SelectByID(id);
            Customer existing = repository.SelectByID(id);
            return View(existing);
        }

        public ActionResult Update(Customer obj)
        {
            repository.Update(obj);
            repository.Save();
          //  return View();
            string message = "Customer updated " + obj.CompanyName + " " + DateTime.Now;
            var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.addNewMessageToPage(message);
            List<Customer> model = (List<Customer>)repository.SelectAll();
            context.Clients.All.updateCustomerList(model);

            return RedirectToAction("Index");
        }

        public ActionResult ConfirmDelete(int id)
        {
            Customer existing = repository.SelectByID(id);
            return View(existing);
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return View();
        }

        public ActionResult Details(int id) 
        {
            Customer c = repository.SelectByID(id);
            return View("Details",c);        
        }
        
    }
}
