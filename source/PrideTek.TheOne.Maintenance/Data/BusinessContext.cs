using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Maintenance.Data
{
    public sealed class BusinessContext : IDisposable
    {
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContext"/> class.
        /// </summary>
        public BusinessContext()
        {
        }
        public DataContext DataContext
        {
            get { return new DataContext(); }
        }

        #region AppUser Members

        public void DeleteAppUser(AppUser appUser)
        {
            var context = DataContext;
            context.AppUsers.Attach(appUser);
            context.AppUsers.Remove(appUser);
            context.SaveChanges();   
        }
        public void UpdateAppUser(AppUser appUser)
        {
           if (appUser.AppUserId == null)
            {
                var context = DataContext;
                context.AppUsers.Add(appUser);
                context.SaveChanges();
                appUser.IsDirty = false;
            }     
            else
            {
                var context = DataContext;
                context.AppUsers.Attach(appUser);
                context.SetModified(appUser);
                context.SaveChanges();
                appUser.IsDirty = false;
            }
        }

        public List<AppUser> GetAppUsers()
        {
            var items = DataContext.AppUsers.OrderBy(p => p.AppUserId).ToList();
            return items;
        }
        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentException();
                if (value.Trim().Length == 0)
                    throw new ArgumentException();
            }
        }
        #endregion

        #region Customer Members

        public List<Customer> GetCustomers()
        {
            var items = DataContext.Customers.OrderBy(p => p.CustomerID).ToList();
            return items;
        }
        public string UpdateCustomer(Customer customer)
        {
            if (customer.CustomerID == null)
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
        public void DeleteCustomer(Customer customer)
        {
            var context = DataContext;
            context.Customers.Attach(customer);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public Customer GetCustomerById(int CustId)
        {
            var context = DataContext;
            var customer = context.Customers.Find(CustId);
            customer.IsDirty = false;
            return customer;
        }
        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (DataContext != null)
                DataContext.Dispose();

            disposed = true;

        }

        #endregion  
    }
}
