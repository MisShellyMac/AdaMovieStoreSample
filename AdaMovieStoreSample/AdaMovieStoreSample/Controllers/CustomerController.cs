using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaMovieStoreSample.Models;
using AdaMovieStoreSample.DataLayer;

namespace AdaMovieStoreSample.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerRepository r = new CustomerRepository();
            List<Customer> customers = r.GetAll();
            return View(customers);
        }

        // GET: Customer/CustDetail/5
            public ActionResult CustDetail(int id = 1)
        {
            CustomerRepository r = new CustomerRepository();
            Customer customers = r.Find(id);
            return View(customers);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Customer customer = new Customer();
                customer.Name = collection.GetValue("Name").AttemptedValue.ToString();
                customer.RegisteredAt = collection.GetValue("RegisteredAt").AttemptedValue.ToString();        
                customer.Address = collection.GetValue("Address").AttemptedValue.ToString();
                customer.City= collection.GetValue("City").AttemptedValue.ToString();
                customer.State = collection.GetValue("State").AttemptedValue.ToString();
                customer.PostalCode = collection.GetValue("PostalCode").AttemptedValue.ToString();
                customer.Phone = collection.GetValue("Phone").AttemptedValue.ToString();
                customer.AccountCredit = decimal.Parse(collection.GetValue("AccountCredit").AttemptedValue.ToString());

                CustomerRepository r = new CustomerRepository();
                r.Add(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerRepository r = new CustomerRepository();
            Customer customers = r.Find(id);
            return View(customers);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Customer customer = new Customer();
                customer.Name = collection.GetValue("Name").AttemptedValue.ToString();
                customer.RegisteredAt = collection.GetValue("RegisteredAt").AttemptedValue.ToString();
                customer.Address = collection.GetValue("Address").AttemptedValue.ToString();
                customer.City = collection.GetValue("City").AttemptedValue.ToString();
                customer.State = collection.GetValue("State").AttemptedValue.ToString();
                customer.PostalCode = collection.GetValue("PostalCode").AttemptedValue.ToString();
                customer.Phone = collection.GetValue("Phone").AttemptedValue.ToString();
                customer.AccountCredit = decimal.Parse(collection.GetValue("AccountCredit").AttemptedValue.ToString());
                customer.Id = id;

                CustomerRepository r = new CustomerRepository();
                r.Update(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            CustomerRepository r = new CustomerRepository();
            Customer customers = r.Find(id);
            return View(customers);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Customer movie = new Customer();
                CustomerRepository r = new CustomerRepository();
                r.Remove(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
