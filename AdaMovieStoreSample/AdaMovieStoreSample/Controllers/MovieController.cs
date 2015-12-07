using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaMovieStoreSample.Models;
using AdaMovieStoreSample.DataLayer;
using System.Data.SqlClient;

namespace AdaMovieStoreSample.Controllers
{
    public class MovieController : Controller
    {
        public SqlConnection db { get; private set; }

        // GET: Movie
        public ActionResult Index()
        {
            MovieRepository r = new MovieRepository();
            List<Movie> movies = r.GetAll();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult MovieDetail(int id = 1)
        {
            MovieRepository r = new MovieRepository();
            Movie movie = r.Find(id);
            return View(movie);
        }



        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Movie movie = new Movie();
                movie.Inventory = int.Parse(collection.GetValue("Inventory").AttemptedValue.ToString());
                movie.Overview = collection.GetValue("Overview").AttemptedValue.ToString();
                movie.ReleaseDate = collection.GetValue("ReleaseDate").AttemptedValue.ToString();
                movie.Title = collection.GetValue("Title").AttemptedValue.ToString();

                MovieRepository r = new MovieRepository();
                r.Add(movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieRepository r = new MovieRepository();
            Movie movie = r.Find(id);
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Movie movie = new Movie();
                movie.Inventory = int.Parse(collection.GetValue("Inventory").AttemptedValue.ToString());
                movie.Overview = collection.GetValue("Overview").AttemptedValue.ToString();
                movie.ReleaseDate = collection.GetValue("ReleaseDate").AttemptedValue.ToString();
                movie.Title = collection.GetValue("Title").AttemptedValue.ToString();
                movie.Id = id;
                MovieRepository r = new MovieRepository();
                r.Update(movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            MovieRepository r = new MovieRepository();
            Movie movie = r.Find(id);
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Movie movie = new Movie();
                MovieRepository r = new MovieRepository();
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
