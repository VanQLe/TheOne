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

namespace PrideTek.TheOne.Maintenance.ViewModels
{
   
    public abstract class MaintenanceViewVM: BaseViewModel
    {
        public MaintenanceViewVM()
        {
            //Commands
            AddNewCommand = new DelegateCommand(AddNew);
            UpdateCommand = new DelegateCommand(Save);
            DeleteCommand = new DelegateCommand(Delete);
            ResetEditCommand = new DelegateCommand(ResetEntity);
        }

        //Commands
        public DelegateCommand ResetEditCommand { get; set; }
        public DelegateCommand AddNewCommand { get; set; }
        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        /// <summary>
        /// Set the Name of the View
        /// </summary>
        private string _ViewTitleName;
        public string ViewTitleName
        {
            get
            {
                return _ViewTitleName;
            }
            set
            {
                SetField(ref _ViewTitleName, value);
            }
        }

        /// <summary>
        /// Show the status of the view
        /// </summary>
        private string _ViewStatus;
        public string ViewStatus
        {
            get
            {
                return _ViewStatus;
            }

            set
            {
                SetField(ref _ViewStatus, value);
            }
        }

        /// <summary>
        /// The Customer List
        /// </summary>
        private List<Entity> _Entities;
        public List<Entity> Entities
        {
            get
            {
                return _Entities;
            }

            set
            {
                SetField(ref _Entities, value);
            }
        }

        /// <summary>
        /// The List of customer used to display in the view
        /// </summary>
        private ListCollectionView _EntityCollection;
        public ListCollectionView EntityCollection
        {
            get
            {
                return _EntityCollection;
            }

            set
            {
                SetField(ref _EntityCollection, value);
            }
        }

        /// <summary>
        /// The current customer that's selected from the Customer list
        /// </summary>
        private Entity _CurrentSelectedItem;

        public Entity CurrentSelectedItem
        {
            get
            {
                return _CurrentSelectedItem;
            }
            set
            {
                if (SelectedItem != null && SelectedItem.IsDirty == true)
                {
                    AskSaveChanges();
                }
                SetField(ref _CurrentSelectedItem, value);
                CloneSelectedItem();
            }
        }

        /// <summary>
        /// A clone of the current selected customer from the list for editing reasons.
        /// </summary>
        private Entity _SelectedItem;
        public Entity SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                SetField(ref _SelectedItem, value);
            }
        }

        protected  void AddNew()
        {
            if (SelectedItem != null && SelectedItem.IsDirty == true)
            {
                AskSaveChanges();
            }
            AddNewEntity(); //Create a new Customer or AppUser
            SelectedItem.IsDirty = false;
            ViewStatus = "Please enter a new customer information";
        }
    
        protected void GetEntityList()
        {
            GetList();//Uses ClientService
            EntityCollection = new ListCollectionView(Entities);
            EntityCollection.MoveCurrentTo(null);
            CurrentSelectedItem = null;
            SelectedItem = null;
        }
        protected abstract void AddNewEntity();

        protected abstract void GetList();
  

        protected  void Save()
        {
            if (SelectedItem != null && SelectedItem.IsDirty == true)
            {
                SaveEntity();
                GetEntityList();
            }
            else
            {
                ViewStatus = "Entry was not saved";
            }
        }

        protected abstract void SaveEntity();

        protected void Delete()
        {
            if (SelectedItem != null && SelectedItem.IsNew != true)
            {
                if (MessageBox.Show(String.Format("Do you wish to delete {0} {1} Customer?", SelectedItem.FirstName, SelectedItem.LastName), "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    DeleteEntity();
                    ViewStatus = String.Format("{0} {1} have been deleted!", SelectedItem.FirstName, SelectedItem.LastName);
                    GetEntityList();
                }
            }
        }

        protected abstract void DeleteEntity();

        protected void ResetEntity()
        {
            if (SelectedItem != null)
            {
                ResetEntityEdit();
                ViewStatus = "Information has been reset back to it's original";
            }
        }

        protected abstract void ResetEntityEdit();

        protected virtual void CloneSelectedItem()
        {
            if (CurrentSelectedItem != null)
            {
                Clone();
            }
        }

        protected abstract void Clone();
        protected virtual void AskSaveChanges()
        {
            if (MessageBox.Show("Value Has Been edited, do you wish to save the change?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                SaveEntity();
            }
        }
    }
}
