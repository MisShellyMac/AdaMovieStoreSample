using AdaMovieStoreSample.DataLayer;
using AdaMovieStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaMovieStoreSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Customers()
        {
            CustomerRepository r = new CustomerRepository();
            List<Customer> customers = r.GetAll();
            return View(customers);
        }

        public ActionResult CustomerDetail(int id = 1)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
