using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.ClientServices
{
    public class AppUserClientService : BaseClientService,  IAppUserClientService
    {
        public AppUserClientService()
        {

        }



        public void DeleteAppUser(AppUser appUser)
        {
            var context = DataContext;
            context.AppUsers.Attach(appUser);
            context.AppUsers.Remove(appUser);
            context.SaveChanges();
        }

        public AppUser GetAppUserById(int appUserId)
        {
            var context = DataContext;
            var appUser = context.AppUsers.Find(appUserId);
            appUser.IsDirty = false;
            return appUser;
        }

        public List<AppUser> GetAppUsers()
        {
            var items = DataContext.AppUsers.OrderBy(p => p.Id).ToList();
            return items;
        }

        public string UpdateAppUser(AppUser appUser)
        {
            if (appUser.Id == null)
            {
                var context = DataContext;
                context.AppUsers.Add(appUser);
                context.SaveChanges();
                appUser.IsDirty = false;

                return "New AppUser Saved.";
            }
            else
            {
                var context = DataContext;
                context.AppUsers.Attach(appUser);
                context.SetModified(appUser);
                context.SaveChanges();
                appUser.IsDirty = false;

                return "AppUser information updated.";
            }
        }
    }
}
