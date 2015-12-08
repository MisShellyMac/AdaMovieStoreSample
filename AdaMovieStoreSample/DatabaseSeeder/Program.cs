using AdaMovieStoreSample.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.SeedMovies();
            Seeder.SeedCustomers();
        }
    }
}
