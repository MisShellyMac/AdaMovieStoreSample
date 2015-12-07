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
    public class CustomerRepository
    {
        private SqlConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=C:\GitHub\AdaMovieStoreSample\AdaMovieStoreSample\AdaMovieStoreSample\App_Data\videoStore.mdf;Integrated Security=True");

        public List<Customer> GetAll()
        {
            return this.db.Query<Customer>("select * from customers").ToList();
        }

        public Customer Find(int id)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("id", id);

            return this.db.Query<Customer>("select * from customers where id=@id", dbArgs).First();
        }

        public void Add(Customer customer)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand(
                    "insert into customers (name, registeredAt, address, city, state, postalCode, phone, accountCredit) values (@name, @registered_at, @address, @city, @state, @postal_code, @phone, @account_credit)",
                    this.db);
                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@registered_at", customer.RegisteredAt);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@city", customer.City);
                command.Parameters.AddWithValue("@state", customer.State);
                command.Parameters.AddWithValue("@postal_code", customer.PostalCode);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@account_credit", customer.AccountCredit);

                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public void Update(Customer customer)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand(
                    "update customers set name=@name, registeredAt=@registered_at, address=@address, city=@city, state=@state, postalCode=@postal_code, phone=@phone, accountCredit=@account_credit where id=@id",
                    this.db);
                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@registered_at", customer.RegisteredAt);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@city", customer.City);
                command.Parameters.AddWithValue("@state", customer.State);
                command.Parameters.AddWithValue("@postal_code", customer.PostalCode);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@account_credit", customer.AccountCredit);
                command.Parameters.AddWithValue("@id", customer.Id);

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
                SqlCommand command = new SqlCommand("delete from customers where id = @id", this.db);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public Customer GetFullCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
