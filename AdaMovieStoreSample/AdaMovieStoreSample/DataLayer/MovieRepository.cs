using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using AdaMovieStoreSample.Interfaces;
using AdaMovieStoreSample.Models;
using Dapper;

namespace AdaMovieStoreSample.DataLayer
{
    public class MovieRepository
    {
        //private SqlConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=C:\GitHub\AdaMovieStoreSample\AdaMovieStoreSample\AdaMovieStoreSample\App_Data\videoStore.mdf;Integrated Security=True");
        private SqlConnection db = new SqlConnection("Server=tcp:newmoviestore.database.windows.net,1433;Database=newmoviestore;User ID=michelle;Password=E123456e;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public List<Movie> GetAll()
        {
            return this.db.Query<Movie>("select * from movies").ToList();
        }

        public Movie Find(int id)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("id", id);

            return this.db.Query<Movie>("select * from movies where id=@id", dbArgs).First();
        }

        public void Add(Movie movie)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand(
                    "insert into movies (title, overview, releaseDate, inventory) values (@title, @overview, @release_date, @inventory)",
                    this.db);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@overview", movie.Overview);
                command.Parameters.AddWithValue("@release_date", movie.ReleaseDate);
                command.Parameters.AddWithValue("@inventory", movie.Inventory);

                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public void Update(Movie movie)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand(
                    "update movies set title=@title, overview=@overview, releaseDate=@release_date, inventory=@inventory where id = @id",
                    this.db);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@overview", movie.Overview);
                command.Parameters.AddWithValue("@release_date", movie.ReleaseDate);
                command.Parameters.AddWithValue("@inventory", movie.Inventory);
                command.Parameters.AddWithValue("@id", movie.Id);
                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public void Remove(int id)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand("delete from movies where id = @id", this.db);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public Movie GetFullMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
