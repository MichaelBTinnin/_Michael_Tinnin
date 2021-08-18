using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _Michael_Tinnin.Models
{
    public class MailViewModel
    {
        public Mail Mail { get; set; }

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
        public MailViewModel()
        {
            Mail = new Mail();
        }
    }
    public class ListItem
    {
        public string Description { get; set; }
        public string Value { get; set; }

        public ListItem(string description, string value)
        {
            Description = description;
            Value = value;
        }
    }
}


