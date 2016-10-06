using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public class CustomerClientService : BaseClientService,  ICustomerClientService
    {
        public CustomerClientService()
        {

        }

        public void DeleteCustomer(Customer customer)
        {
            var context = DataContext;
            context.Customers.Attach(customer);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            var items = DataContext.Customers.OrderBy(p => p.Id).ToList();
            return items;
        }

        public Customer GetCustomerById(int customerId)
        {
            var context = DataContext;
            var customer = context.Customers.Find(customerId);
            customer.IsDirty = false;
            return customer;
        }

        public string UpdateCustomer(Customer customer)
        {
            if (customer.Id == null)
            {
                var context = DataContext;
                context.Customers.Add(customer);
                context.SaveChanges();
                customer.IsDirty = false;
                return "New Customer saved.";
            }
            else
            {
                var context = DataContext;
                context.Customers.Attach(customer);
                context.SetModified(customer);
                context.SaveChanges();
                customer.IsDirty = false;
                return "Customer information updated";
            }
        }
    }
}
