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

        public ActionResult Movies()
        {
            MovieRepository r = new MovieRepository();
            List<Movie> movies = r.GetAll();
            return View(movies);
        }


        private ActionResult View(Func<ActionResult> addMovie)
        {
            throw new NotImplementedException();
        }

        public ActionResult MovieDetail(int id = 1)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult CustomerDetail(int id = 1)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
