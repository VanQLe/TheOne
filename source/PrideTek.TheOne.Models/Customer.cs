using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Models
{
    public class Customer : Entity
    {
        //public string CustomerInfo
        //{
        //    get
        //    {
        //        return this.ToString();
        //    }
        //}

        //Check if Customer is saved in the data base or not.  If it's saved in the database, EntityFrameWork will set an ID to CustomerID property
        //[NotMapped]
        //public bool? IsNew
        //{
        //    get
        //    {
        //        return CustomerID == null;
        //    }
        //}
        ////Customer ID
        //public int? CustomerID { get; set; }

        //Customer First Name
        //private string _FirstName;
        //public string FirstName
        //{
        //    get
        //    {
        //        return _FirstName;
        //    }

        //    set
        //    {
        //        SetField(ref _FirstName, value); ;
        //    }
        //}
        //Customer Last Name
        //private string _LastName;
        //public string LastName
        //{
        //    get
        //    {
        //        return _LastName;
        //    }

        //    set
        //    {
        //        SetField(ref _LastName, value);
        //    }
        //}
        //Customer Email
        //private string _Email;
        //public string Email
        //{
        //    get
        //    {
        //        return _Email;
        //    }

        //    set
        //    {
        //        SetField(ref _Email, value);
        //    }

        //}

        ///// <summary>
        ///// return a clone of the customer
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <returns></returns>
        //public Customer Clone()
        //{
        //    Customer clone = new Customer();
        //    clone.Id = this.Id;
        //    clone.FirstName = this.FirstName;
        //    clone.LastName = this.LastName;
        //    clone.Email = this.Email;
        //    return clone;
        //}

        /// <summary>
        /// Format the Customer information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            result += "This is a Customer\n";

            result += String.Format("First Name:{0} Last Name: {1} Email: {2}", FirstName, LastName, Email);

            return result;
        }
    }
}
