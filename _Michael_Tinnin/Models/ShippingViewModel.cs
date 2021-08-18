using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _Michael_Tinnin.Models
{
    public class ShippingViewModel
    {
        public Package Package { get; set; }
        public string ShippingType { get; set; }
        //this is in the view model instead of Package because it's purely for the UI
        public string PackageType { get; set; }

        public SelectList StateList
        {
            get
            {
                //create a collection of States
                List<ListItem> states = new List<ListItem>();
                //Add some items to the list
                states.Add(new ListItem("Colorado", "Colorado"));
                states.Add(new ListItem("New York", "New York"));
                states.Add(new ListItem("California", "California"));
                states.Add(new ListItem("New Mexico", "New mexico"));
                states.Add(new ListItem("Arizona", "Arizona"));

                //create a new SelectList passing in the list of ListItem, Value as the value field, 
                //Description as the description field
                return new SelectList(states, "Value", "Description");
            }
        }
        public List<ListItem> ShippingTypeList
        {
            get
            {
                List<ListItem> shipping = new List<ListItem>();

                shipping.Add(new ListItem("Standard", "Standard"));
                shipping.Add(new ListItem("Two Day", "Two Day"));
                shipping.Add(new ListItem("Overnight", "Overnight"));

                return shipping;
            }
        }
        public ShippingViewModel()
        {
            
            Package = new Package();
           
            ShippingType = "Standard";
        }
        
        
    }
    
}
