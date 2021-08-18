using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Models
{
    [Serializable]
    public class PackageData
    {
        private readonly List<Package> _packages = new List<Package>();
        
        public List<Package> Packages
        {
            get
            {
                return _packages;
            }
        }
    }
}