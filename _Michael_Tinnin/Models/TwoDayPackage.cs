using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    [Serializable]
    public class TwoDayPackage : Package
    {
        
        private Decimal _FlatFee;
        public Decimal FlatFee
        {
            get
            {
                return _FlatFee;
            }
            set
            {
                _FlatFee = value;
            }
        }
        public override Decimal ExtendedCost
        {
            
            get
            {
                
                return (Weight * CostPerOunce) + FlatFee;
            }
        }
        public TwoDayPackage(Decimal flatFee)
        {
            
            _FlatFee = flatFee;
            
        }
        public TwoDayPackage()
        {
            _FlatFee = 5;
        }
    }
}