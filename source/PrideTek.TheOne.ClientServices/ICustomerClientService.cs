using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public interface ICustomerClientService 
    {
        /// <summary>
        ///  Return a new DataContext
        /// </summary>
        DataContext DataContext { get; }

        /// <summary>
        /// Delete the customer from the database
        /// </summary>
        /// <param name="customer"></param>
        void DeleteCustomer(Customer customer);

        /// <summary>
        /// Update an exisiting customer or save a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        String UpdateCustomer(Customer customer);

        /// <summary>
        /// Return the Customer Collection from the database
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Get a Customer from the database by its Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);
    }
}

