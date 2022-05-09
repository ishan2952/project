using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var customer = context.Customers.ToList();
            return View(customer);
        }

        public ActionResult CreateNewCustomer()
        {
            var context = new TechSupportEntities();
            return View();
        }

        public ActionResult AddNewToDB(Customer customer)
        {
            var context = new TechSupportEntities();
            context.Customers.Add(customer);
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult EditCustomer(int id)
        {
            var context = new TechSupportEntities();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            return View(customer);
        }

        public ActionResult edtcust(int id, Customer customer)
        {
            var context = new TechSupportEntities();
            var cust = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            cust.Name = customer.Name;
            cust.Address = customer.Address;
            cust.City = customer.City;
            cust.State = customer.State;
            cust.ZipCode = customer.ZipCode;
            cust.Phone = customer.Phone;
            cust.Email = customer.Email;
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult ShowCustomer(int id)
        {
            var context = new TechSupportEntities();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            return View(customer);
        }

       public ActionResult DeleteCustomer(int id)
        {
            var context = new TechSupportEntities();
            Customer customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            if (customer == null)
            {
                customer = new Customer();
            }
            return View(customer);
        }

        public ActionResult DeleteFromDB(int id)
        {
            var context = new TechSupportEntities();
            try
            {
                IEnumerable<Registration> r = context.Registrations.Where(a => a.CustomerID == id);
                foreach(Registration registration in r)
                {
                    context.Registrations.Remove(registration);
                }

                Customer c = context.Customers.Where(a => a.CustomerID == id).FirstOrDefault();
                context.SaveChanges();
                context.Customers.Remove(c);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
               
            }
            return Redirect("/Customer/Index");

            //return View("Index");
        }
    }
}