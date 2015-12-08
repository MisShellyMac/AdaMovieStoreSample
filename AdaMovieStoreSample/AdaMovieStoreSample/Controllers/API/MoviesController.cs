using AdaMovieStoreSample.DataLayer;
using AdaMovieStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdaMovieStoreSample.Controllers
{
    [Authorize]
    public class MoviesController : ApiController
    {

        public Movie AddMovie()
        {
            return new Movie();
        }


        // GET api/movies
        public IEnumerable<Movie> Get()
        {
            MovieRepository r = new MovieRepository();
            return r.GetAll();
        }

        // GET api/movies/5
        public Movie Get(int id)
        {
            MovieRepository r = new MovieRepository();
            return r.Find(id);
        }

        // POST api/movies
        public void Post([FromBody]string title, [FromBody]string overview, [FromBody]string releaseDate, [FromBody]string inventory)
        {
        }

        // PUT api/movies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/movies/5
        public void Delete(int id)
        {
        }
    }
}
