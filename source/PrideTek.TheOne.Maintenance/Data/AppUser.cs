using PrideTek.Shell.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Maintenance.Data
{
    public class AppUser : Entity
    {
        [NotMapped]  
        public bool? IsNew
        {
            get
            {
                return AppUserId == null;
            }
        }
        private string _UserInfo;
        public string UserInfo
        {
            get
            {
                return this.ToString();
            }
           
        }
      
        public int? AppUserId { get; set; }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                SetField(ref _FirstName, value);
                
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                SetField(ref _LastName, value);//check if value is differernt, change if value are differernt and call NotifyPropertyChanged
            }
        }
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetField(ref _Email, value);
            }
        }
        private bool _IfPropertyChanged(string currentValue, string passInValue)
        {
            return currentValue != passInValue;
        }

        public AppUser Clone()
        {
            AppUser clone = new AppUser();
            clone.FirstName = this.FirstName;
            clone.LastName = this.LastName;
            clone.Email = this.Email;
            clone.AppUserId = this.AppUserId;

            return clone;

        }

        public override string ToString()
        {
            string result = "";
            result += String.Format("First Name:{0} Last Name: {1} Email: {2}", FirstName, LastName, Email);

            return result;
        }
    }
}
