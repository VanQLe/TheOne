using PrideTek.TheOne.ClientServices;
using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrideTek.TheOne.ClientServices
{
    public class ClientServices<T> : IClientServices<T> where T: Entity
    {
        /// <summary>
        /// Return a new DataContext
        /// </summary>
        public DataContext DataContext
        {
            get
            {
                return new DataContext();
            }
        }

        public void DeleteEntity(T entity)
        {
            var context = DataContext;
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            MessageBox.Show("Deleted");
        }

        public List<T> GetEntities()
        {
            var context = DataContext;
            var entities = context.Set<T>().ToList<T>();

            return entities;
        }

        //        /// <summary>
        //        /// Add a new entity<T> to the database
        //        /// </summary>
        //        /// <param name="Entity"></param>
        //        public void AddNewEntity(T entity)
        //        {
        //            var context = DataContext;
        //            context.Set<T>().Add(entity);
        //            context.SaveChanges();
        //            entity.IsDirty = false;

        //        }

        //        /// <summary>
        //        /// Delete the entity from the database
        //        /// </summary>
        //        /// <param name="entity"></param>
        //        public void DeleteEntity(T entity)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        public List<T> GetEntities()
        //        {
        //            throw new NotImplementedException();
        //        }

        public T GetEntityById(int entityId)
        {
            var context = DataContext;
            var entity = context.Set<T>().Find(entityId);
            entity.IsDirty = false;
            return entity;
        }

        public string UpdateEntity(T entity)
        {
            if (entity.Id == null)
            {
                var context = DataContext;
                context.Set<T>().Add(entity);
                context.SaveChanges();
                entity.IsDirty = false;

                return "New AppUser Saved.";
            }
            else
            {
                var context = DataContext;
                context.Set<T>().Attach(entity);
                context.SetModified(entity);
                context.SaveChanges();
                entity.IsDirty = false;

                return "AppUser information updated.";
            }
        }

        //        public void UpdateEntity(T Enitity)
        //        {
        //            throw new NotImplementedException();
        //        }
    }
}
