using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    [Serializable]
    public class OvernightPackage : Package
    {
        private Decimal _AdditionalFee;
        public Decimal AdditionalFee
        {
            get
            {
                return _AdditionalFee;
            }
            set
            {
                _AdditionalFee = value;
            }
        }
        public override Decimal ExtendedCost
        {
            get
            {
                Decimal cost = 0;
                CostPerOunce = _AdditionalFee + CostPerOunce;
                cost = (Weight * CostPerOunce);
                return cost;
            }
        }

        public OvernightPackage()
        {
            _AdditionalFee = 8;
        }
    }
}