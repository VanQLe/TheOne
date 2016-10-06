using Pridetek.Shell.WPF;
using PrideTek.Shell.Core;
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

namespace PrideTek.TheOne.Maintenance.Data
{
    public class AppUserViewVM: BaseViewModel
    {
        private readonly BusinessContext context;
        private int CurrentSelectedUserID;
        private bool ValueChange;
        private bool _ResetValue = false;
        private bool _IsInitialized { get; set; }

        public AppUserViewVM()
        {
           
        }
        public AppUserViewVM(BusinessContext context)
        {
            ValueChange = true;
            this.context = context;
            GetAppUserList();
            _IsInitialized = true;
            ViewHeaderName = "Application User View";
          
        }

        //public bool IsValid
        //{
        //    get
        //    {
        //        return SelectedAppUser == null ||
        //               (
        //                   !String.IsNullOrWhiteSpace(SelectedAppUser.FirstName) &&
        //                   !String.IsNullOrWhiteSpace(SelectedAppUser.LastName) &&
        //                   !String.IsNullOrWhiteSpace(SelectedAppUser.Email)
        //               );
        //    }
        //}
        private string _ViewHeaderName;
        public string ViewHeaderName
        {
            get
            {
                return _ViewHeaderName;
            }
            set
            {
                SetField(ref _ViewHeaderName, value);
            }
        }
        private List<AppUser> _AppUsers;
        public List<AppUser> AppUsers
        {
            get
            {
                return _AppUsers;
            }
            set
            {
                _AppUsers = value;
                NotifyPropertyChanged();
            }
        }
        private AppUser _SelectedItem;

        public AppUser SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                         _SelectedItem = value;
            }
        }
        private AppUser _SelectedAppUser;

        public AppUser SelectedAppUser
        {
            get
            {
                return _SelectedAppUser;
            }

            set
             {
                if (SelectedAppUser != null && SelectedAppUser.IsDirty)
                {      
                    if(CurrentSelectedUserID != SelectedAppUser.AppUserId || value.IsNew == true)
                    {
                        if (MessageBox.Show("Value will change", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                        {
                            _SelectedAppUser = value;
                            NotifyPropertyChanged();
                            MessageBox.Show("Value changed");
                        }
                    }
                    else if(_ResetValue)
                    {
                        _SelectedAppUser = value;
                        NotifyPropertyChanged();
                    }   
                }
                else
                {
                    _SelectedAppUser = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ICommand ResetAppUserCommand
        {
            get
            {
                return new ActionCommand(p => ResetAppUser());
                                        
            }
        }
        private void ResetAppUser()
        {
            StatusLabel = "";
            if (SelectedItem != null)
            {
                _ResetValue = true;
                SelectedAppUser = SelectedItem.Clone() ;
            }

        }
        private void GetAppUserList()
        {
            
            AppUsers = context.GetAppUsers();
            AppUserCollection = new ListCollectionView(AppUsers);
            AppUserCollection.MoveCurrentTo(null);
            //SelectedAppUser = null;
            StatusLabel = "";
        }
        public ICommand AddAppUserCommand
        {
            get
            {
                return new ActionCommand(p => AddAppUser());
                                         
            }
        }
        private void AddAppUser()
        {
            StatusLabel = "Please Enter New User Info.";
            //  using (var api = new BusinessContext())
            // {
            var appUser = new AppUser
            {
                FirstName = "New",
                LastName = "User",
                Email = "new@User.com"
                };
                SelectedAppUser = appUser;

        }
        public ICommand UpdateAppUserCommand
        {
            get
            {
                return new ActionCommand(p => SaveCustomer());
            }
        }
        private void SaveCustomer()
        {
            if (SelectedAppUser != null)
            {
                context.UpdateAppUser(SelectedAppUser);
                GetAppUserList();
                StatusLabel = "";
                //SelectedAppUser = SelectedAppUser;
            }
            //SelectedAppUser = SelectedAppUser;
        }

        public ICommand DeleteAppUserCommand
        {
            get
            {
                return new ActionCommand(p => DeleteAppUser()
                                         /*p => IsValid*/);
            }
        }
        private void DeleteAppUser()
        {
            StatusLabel = "";
            if (SelectedAppUser != null)
            {
                context.DeleteAppUser(SelectedAppUser);
                //SelectedAppUser = null;
                GetAppUserList();
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new ActionCommand(p => GetAppUserList());
            }
        }
        private List<AppUser> _AppUserList;
        public List<AppUser> AppUserList
        {
            get
            {
                return _AppUserList;
            }

            set
            {
                _AppUserList = value;
                NotifyPropertyChanged();
            }
        }

        private ListCollectionView _AppUserCollection;
        public ListCollectionView AppUserCollection
        {
            get
            {
                return _AppUserCollection;
            }
            set
            {
                if (_AppUserCollection != null)
                {
                    _AppUserCollection.CurrentChanged -= AppUserCollection_CurrentChanged;
                }

                _AppUserCollection = value;
                if (_AppUserCollection != null)
                {
                    _AppUserCollection.CurrentChanged += AppUserCollection_CurrentChanged;
                }
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// This method is called when AppUserCollect has value changes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppUserCollection_CurrentChanged(object sender, EventArgs e)
        {
            if (!_IsInitialized) return;
           
            var tempCurrentItem = (AppUser)AppUserCollection.CurrentItem;
            //if(tempCurrentItem != null)
            //{
            //    CurrentSelectedUserID = (int)tempCurrentItem.AppUserId;
            //}
            if (tempCurrentItem != null)
            {
                CurrentSelectedUserID = (int)tempCurrentItem.AppUserId;
                //SelectedAppUser = context.DataContext.AppUsers.Find(tempCurrentItem.AppUserId);
                SelectedAppUser = tempCurrentItem;
                SelectedItem = SelectedAppUser.Clone();
            }
  
        }

        private bool _CheckIfObjectValuesEqual(AppUser userA, AppUser userB)
        {
            return userA.FirstName.Equals(userB.FirstName) && userA.LastName.Equals(userB.LastName) && userA.Email.Equals(userB.Email);
        }

        private string _StatusLabel;
        public string StatusLabel
        {
            get
            {
                return _StatusLabel;
            }

            set
            {
                _StatusLabel = value;
                NotifyPropertyChanged();
            }
        }

    }
}
