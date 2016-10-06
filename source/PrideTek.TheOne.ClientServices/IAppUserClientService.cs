using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public interface IAppUserClientService 
    {
        
        /// <summary>
        /// Return a new DataContext
        /// </summary>
        /// <returns></returns>
        DataContext DataContext { get; }

        /// <summary>
        /// Delete the AppUser from the database
        /// </summary>
        /// <param name="appUser"></param>
        void DeleteAppUser(AppUser appUser);

        /// <summary>
        /// Update an exisiting AppUser or Save a new AppUser
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        string UpdateAppUser(AppUser appUser);

        /// <summary>
        /// Return the AppUser Collection from the database
        /// </summary>
        /// <returns></returns>
        List<AppUser> GetAppUsers();

        /// <summary>
        /// Get an AppUser from the database by its Id
        /// </summary>
        /// <param name="appUserId"></param>
        /// <returns></returns>
        AppUser GetAppUserById(int appUserId);

    }
}
