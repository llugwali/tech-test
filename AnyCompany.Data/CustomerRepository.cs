using AnyCompany.Data.Contracts;
using AnyCompany.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    public  class CustomerRepository: ICustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";

        public  Customer Load(int customerId)
        {
            Customer customer = new Customer();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                customer.Name = reader["Name"].ToString();
                customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                customer.Country = reader["Country"].ToString();
            }


            customer.Orders = GetCustomerOrders(customerId);
            connection.Close();

            return customer;
        }

        private List<Order> GetCustomerOrders(int customerId)
        {
            List<Order> orders = new List<Order>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Order  WHERE CustomerId = " + customerId,
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var order = new Order();
                order.OrderId = Convert.ToInt32(reader["OrderId"]);
                order.Amount = Convert.ToDouble(reader["Amount"]);
                orders.Add(order);
            }

            return orders;

        }
    }
}
