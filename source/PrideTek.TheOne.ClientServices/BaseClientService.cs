using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public abstract class BaseClientService
    {
        public DataContext DataContext
        {
            get
            {
                return new DataContext();
            }
        }

        //public Entity GetEntity(Entity entity)
        //{
        //    //this is probably a bad idea

        //    if (entity is Customer)
        //    {
        //        Customer customer = (Customer)entity;
        //        var context = DataContext;
        //        customer = context.Customers.Find(customer.Id);
        //        customer.IsDirty = false;
        //        return customer;
        //    }
        //    else if (entity is AppUser)
        //    {
        //        AppUser appUser = (AppUser)entity;

        //        var context = DataContext;
        //        appUser = context.AppUsers.Find(appUser.Id);
        //        appUser.IsDirty = false;
        //        return appUser;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public void Delete(Entity entity)
        //{
        //    if (entity is Customer)
        //    {
        //        var context = DataContext;
        //        context.Customers.Attach((Customer)entity);
        //        context.Customers.Remove((Customer)entity);
        //        context.SaveChanges();
        //    }

        //    else if (entity is AppUser)
        //    {
        //        var context = DataContext;
        //        context.AppUsers.Attach((AppUser)entity);
        //        context.AppUsers.Remove((AppUser)entity);
        //        context.SaveChanges();
        //    }

        //}

        //public List<Entity> GetEntities(Entity entity)
        //{
        //    if( entity is Customer)
        //    {
        //        var items = DataContext.Customers.OrderBy(p => p.Id).ToList<Entity>();
        //        return items;
        //    }
        //    else if ( entity is AppUser)
        //    {
        //        var items = DataContext.AppUsers.OrderBy(p => p.Id).ToList<Entity>();
        //        return items;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Create new Entity or update current entity
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <returns></returns>
        //public string UpdateEntity(Entity entity)
        //{
        //    if (entity is Customer)
        //    {
        //        Customer customer = (Customer)entity;

        //        if (customer.Id == null)
        //        {
        //            var context = DataContext;
        //            context.Customers.Add(customer);
        //            context.SaveChanges();
        //            customer.IsDirty = false;
        //            return "New Customer saved.";
        //        }
        //        else
        //        {
        //            var context = DataContext;
        //            context.Customers.Attach(customer);
        //            context.SetModified(customer);
        //            context.SaveChanges();
        //            customer.IsDirty = false;
        //            return "Customer information updated";
        //        }
        //    }
        //    else if (entity is AppUser)
        //    {
        //        AppUser appUser = (AppUser)entity;

        //        if (appUser.Id == null)
        //        {
        //            var context = DataContext;
        //            context.AppUsers.Add(appUser);
        //            context.SaveChanges();
        //            appUser.IsDirty = false;
        //            return "New AppUser saved.";
        //        }
        //        else
        //        {
        //            var context = DataContext;
        //            context.AppUsers.Attach(appUser);
        //            context.SetModified(appUser);
        //            context.SaveChanges();
        //            appUser.IsDirty = false;
        //            return "AppUser information updated";
        //        }
        //    }
        //    else
        //        return "No Update Happened";

        //}

        //public List<Entity> GetCustomers(List<Entity> entityList)
        //{
        //    var items = DataContext.Customers.OrderBy(p => p.CustomerID).ToList();
        //    return items;
        //}

    }
}
