//using Pridetek.Shell.WPF;
using PrideTek.Shell.Core;
using PrideTek.TheOne.ClientServices;
using PrideTek.TheOne.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;


namespace PrideTek.TheOne.Maintenance.ViewModels
{
    public class AppUserViewVM : MaintenanceViewVM 
    {
        private readonly IClientServices<AppUser> _ClientService;

        public AppUserViewVM()
        {

        }

        public AppUserViewVM(IClientServices<AppUser> clientService)
        {
            this._ClientService = clientService;
            ViewTitleName = "AppUser Table";
            GetEntityList();
        }

        /// <summary>
        /// Reset back to original values
        /// </summary>
        protected override void ResetEntityEdit()
        {
            SelectedItem = _ClientService.GetEntityById((int)SelectedItem.Id);
        }

        /// <summary>
        /// Allow you to add a new AppUser
        /// </summary>
        protected override void AddNewEntity()
        {
            SelectedItem = new AppUser()
            {
                FirstName = "",
                LastName = "",
                Email = ""
            };
        }

        /// <summary>
        /// Save a new AppUser or update the current selected AppUser
        /// </summary>
        protected override void SaveEntity()
        {
            ViewStatus =_ClientService.UpdateEntity((AppUser)SelectedItem);
            GetEntityList();
        }

        /// <summary>
        /// Refresh the Appuser List
        /// </summary>
        protected override void GetList()
        {
            List<AppUser> Appusers = _ClientService.GetEntities();
            Entities = Appusers.ToList<Entity>();

        }
        
        /// <summary>
        /// Delete the current selected AppUser
        /// </summary>
        protected override void DeleteEntity()
        {
            _ClientService.DeleteEntity((AppUser)SelectedItem);
        }

        /// <summary>
        /// Make a clone of the selected AppUser
        /// </summary>
        protected override void Clone()
        {
            SelectedItem = _ClientService.GetEntityById((int)CurrentSelectedItem.Id);
        }
    }
}
