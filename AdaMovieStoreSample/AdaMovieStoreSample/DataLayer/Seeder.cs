using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using AdaMovieStoreSample.Models;

namespace AdaMovieStoreSample.DataLayer
{
    public class Seeder
    {
        public static void SeedMovies()
        {
            // Read the contents of the file
            string s = File.ReadAllText("..\\..\\..\\AdaMovieStoreSample\\App_Data\\movies.json");
            
            // Parse the contents using JSON.NET
            JArray data = (JArray)JsonConvert.DeserializeObject(s);

            MovieRepository repository = new MovieRepository();

            // Process the data
            foreach (JToken token in data)
            {
                Movie m = new Movie();
                m.Title = token["title"].Value<string>();
                m.Overview = token["overview"].Value<string>();
                m.ReleaseDate = token["release_date"].Value<string>();
                m.Inventory = token["inventory"].Value<int>();

                repository.Add(m);
            }
        }

        public static void SeedCustomers()
        {
            // Read the contents of the file
            string s = File.ReadAllText("..\\..\\..\\AdaMovieStoreSample\\App_Data\\customers.json");

            // Parse the contents using JSON.NET
            JArray data = (JArray)JsonConvert.DeserializeObject(s);

            CustomerRepository repository = new CustomerRepository();

            // Process the data
            foreach (JToken token in data)
            {
                Customer c = new Customer();
                c.Name = token["name"].Value<string>();
                c.RegisteredAt = token["registered_at"].Value<string>();
                c.Address = token["address"].Value<string>();
                c.City = token["city"].Value<string>();
                c.State = token["state"].Value<string>();
                c.PostalCode = token["postal_code"].Value<string>();
                c.Phone = token["phone"].Value<string>();
                c.AccountCredit = token["account_credit"].Value<decimal>();

                repository.Add(c);
            }
        }
    }
}