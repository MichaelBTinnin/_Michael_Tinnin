using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    public class ShippingListViewModel
    {
        public List<Package> Packages { get; set; }

        public ShippingListViewModel()
        {
            Packages = new List<Package>();
        }
    }
}