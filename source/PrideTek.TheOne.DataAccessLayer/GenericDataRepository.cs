using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.DataAccessLayer
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public void Add(params T[] items)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params T[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
