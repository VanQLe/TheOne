using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public interface IClientServices<T>
    {
        DataContext DataContext { get; }
        void DeleteEntity(T entity);
        string UpdateEntity(T Enitity);
        T GetEntityById(int entityId);
        List<T> GetEntities();
    }
}
