//using Pridetek.Shell.WPF;
using PrideTek.Shell.Core;
using PrideTek.TheOne.ClientServices;
using PrideTek.TheOne.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PrideTek.TheOne.Maintenance.ViewModels
{
    public class CustomerViewVM : MaintenanceViewVM
    {
        private readonly IClientServices<Customer> _ClientService;//Crud function object 
        //Default constructor 
        public CustomerViewVM()
        {
        }

        /// <summary>
        /// Constructor with ClientService passed ins
        /// </summary>
        /// <param name="context"></param>
        public CustomerViewVM(IClientServices<Customer> clientService)
        {
            this._ClientService = clientService;
            ViewTitleName = "Customer Table";
            GetEntityList();
        }

        /// </summary>
        protected override void ResetEntityEdit()
        {
            SelectedItem = _ClientService.GetEntityById((int)SelectedItem.Id);
        }
        /// <summary>
        ///Allow you to add a new Customer
        /// </summary>
        protected override void AddNewEntity()
        {
            SelectedItem = new Customer()
            {
                FirstName = "",
                LastName = "",
                Email = ""
            };
        }

        /// <summary>
        /// Save a new Customer or update the current selected customer
        /// </summary>
        protected override void SaveEntity()
        {
            ViewStatus = _ClientService.UpdateEntity((Customer)SelectedItem);
            GetEntityList();
        }

        /// <summary>
        /// Refresh the Customer List
        /// </summary>
        protected override void GetList()
        {
            List<Customer> customers = _ClientService.GetEntities();
            Entities = customers.ToList<Entity>();
        }

        /// <summary>
        /// Delete the selected Customer
        /// </summary>
        protected override void DeleteEntity()
        {
            _ClientService.DeleteEntity((Customer)SelectedItem);
        }

        /// <summary>
        /// Clone the selected customer
        /// </summary>
        protected override void Clone()
        {
            SelectedItem = _ClientService.GetEntityById((int)CurrentSelectedItem.Id);
        }
    }
}
