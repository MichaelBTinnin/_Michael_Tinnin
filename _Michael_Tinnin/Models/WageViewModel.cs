using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    public class WageViewModel
    {
        public Wage Wage { get; set; }

        public WageViewModel()
        {
            Wage = new Wage();
        }
    }
}