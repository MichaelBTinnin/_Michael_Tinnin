using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    public class SessionHelper
    {
        public static List<Package> GetShippingListFromSession()
        {
            List<Package> packages = null;

            //Look in Session for a list of persons with the key of "Persons"
            if (HttpContext.Current.Session["Packages"] != null)
            {
                //Session is of datatype object, must case to a list of package
                packages = HttpContext.Current.Session["Packages"] as List<Package>;
            }
            else
            {
                //if it's not found, create a new empty list
                packages = new List<Package>();
            }

            return packages;
        }

        public static void SetShippingListInSession(List<Package> packages)
        {
            HttpContext.Current.Session["Packages"] = packages;
        }
    }
}