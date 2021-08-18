using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    [Serializable]
    public class Package : IComparable
    {
        public string PackageUniqueId { get; set; }
        public Mail _Sender = new Mail();


        public Mail Sender {get;set;}
        

        private Mail _Recipient = new Mail();
        public Mail Recipient { get; set; }
        

        private Decimal _CostPerOunce;
        public Decimal CostPerOunce
        {
            get
            {
                return _CostPerOunce;
            }
            set
            {
                if( value >= 1)
                {
                    _CostPerOunce = value;
                }
                
            }
        }
        private Decimal _Weight;

        public Decimal Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                if(value >= 1 && value <= 100)
                {
                    _Weight = value;
                }
            }
        }
        public virtual Decimal ExtendedCost
        {

            
            get
            {
                
                return _Weight * _CostPerOunce;
            }
        }
        public string HtmlFormattedShippingLabel
        {
            get
            {
                return "From:<br/>" + Sender.HtmlFormattedFormData + "<br/>To:<br/>" + Recipient.HtmlFormattedFormData;
            }
        }
        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return -1;
            }
            Package otherPackage = obj as Package;
            if (otherPackage != null)
            {
                return this.Sender.LastName.CompareTo(otherPackage.Sender.LastName);
            }
            else
            {
                throw new ArgumentException("Object is not a package.");
            }
        }
        public Package()
        {
            Sender = new Mail();
            Recipient = new Mail();
            _Weight = 1;
            _CostPerOunce = 1;
        }
    }
}