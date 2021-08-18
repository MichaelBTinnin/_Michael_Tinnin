using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace _Michael_Tinnin.Models
{
    [Serializable]
    public class Mail
        
    {
        public string UniqueId { get; set; }
        [Required (ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        public string State { get; set; }
        [Range(10000, 99999, ErrorMessage = "Zip code must be 5 digits")]
        public string ZipCode { get; set; }
        
        public string HtmlFormattedFormData
        {
            get
            {
                StringBuilder label = new StringBuilder();

                
                label.Append(FirstName + " ");
                label.Append(LastName);
                label.Append("<br/>");
                label.Append(Address);
                label.Append("<br/>");
                label.Append(City + ", ");
                label.Append(State + " ");
                label.Append(ZipCode);
                
                return label.ToString();
            }
        }
        public static string GetPackageType(Package package)
        {
            string packageType = "Standard";

            //is tells you the underlying datatype
            if (package is TwoDayPackage)
            {
                packageType = "Two Day";
            }

            if (package is OvernightPackage)
            {
                packageType = "Overnight";
            }

            return packageType;
        }
        

        //constructor with default values
        public Mail()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            State = "Colorado";
            ZipCode = "";
        }
        public Mail(string UniqueId,string FirstName, string LastName, string Address, string City, string State, string ZipCode)
        {
            this.UniqueId = UniqueId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
        }
    }
}