using PrideTek.Shell.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Models
{
    public abstract class Entity : NotificationObject
    {

        public string EntityInfo
        {
            get
            {
                return this.ToString();
            }
        }

        [NotMapped]
        public bool IsDirty { get; set; }

        //Check if Customer is saved in the data base or not.  If it's saved in the database, EntityFrameWork will set an ID to CustomerID property
        [NotMapped]
        public bool? IsNew
        {
            get
            {
                return Id == null;
            }
        }

        public int? Id { get; set; }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                SetField(ref _FirstName, value); ;
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
                SetField(ref _LastName, value);
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

        protected override bool SetField<Tvalue>(ref Tvalue field, Tvalue value, [CallerMemberName] string propertyName = "")
        {
            var result = base.SetField<Tvalue>(ref field, value);
            IsDirty = IsDirty || result;
            return result;
        }

        public override string ToString()
        {
            string result = "";
            result += "This is a Entity\n";

            result += String.Format("First Name:{0} Last Name: {1} Email: {2}", FirstName, LastName, Email);

            return result;
        }


    }
}
