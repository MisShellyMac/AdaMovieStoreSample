using AdaMovieStoreSample.DataLayer;
using AdaMovieStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AdaMovieStoreSample.Controllers
{
    [System.Web.Mvc.Authorize]
    public class CustomersController : ApiController
    {
        // GET api/customers
        public IEnumerable<Customer> Get()
        {
            CustomerRepository r = new CustomerRepository();
            return r.GetAll();
        }

            public ActionResult Customers()
        {
            CustomerRepository r = new CustomerRepository();
            List<Customer> customers = r.GetAll();
            return View(customers);
        }

        private ActionResult View(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

        // GET api/customers/5
        public Customer Get(int id)
        {
            CustomerRepository r = new CustomerRepository();
            return r.Find(id);
        }

        // POST api/customers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
        }
    }
}
