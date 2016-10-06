using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class that will use a default named connection string of 'Default' from the application's configuration file.
        /// </summary>
        public DataContext() : base("Default")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public void SetModified(Entity entity)
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets a collection of AppUser entities.
        /// </summary>
        public DbSet<AppUser> AppUsers { get; set; }


        /// <summary>
        /// Gets a collection of Customer entities
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        //public DbSet<Entity> Entity { get;set }
    }
}
