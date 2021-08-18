using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    public class Wage
    {
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
        public Decimal Hours { get; set; }
        public Decimal Rate { get; set; }
        public String Wage_
        {
            get
            {
                decimal wage = 0;

                if (Hours <= 40)
                {
                    wage = Hours * Rate;
                }
                else
                {
                    decimal overtimeHours = 0;
                    overtimeHours = Hours - 40;

                    wage = (overtimeHours * (1.5M * Rate)) + 40 * Rate;
                }

                return wage.ToString("C");
            }
        }




        public Wage()
        {
            Name = "Michael Tinnin";
            EmployeeNumber = 123456;
            Hours = 40;
            Rate = 10;
            

        }

    }
}