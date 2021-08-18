using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Michael_Tinnin.Helpers;
using _Michael_Tinnin.Models;

namespace _Michael_Tinnin.Controllers
{
    public class ShippingController : Controller
    {
        // GET: ShippingControler
        public ActionResult Index(string id)
        {
            ShippingViewModel model = new ShippingViewModel();
            if (string.IsNullOrEmpty(id))
            {
                //List<Package> packages = SessionHelper.GetShippingListFromSession();
                //Package packages = PackageDataAccess.GetPackage(id);


            }
            else
            {



                //edit mode
                //retrieve from database using unique id
                Package package = PackageDataAccess.GetPackage(id);

                if (package != null)
                {
                    //found the right one, assign it to the view model
                    model.Package = package;

                    //need to help the ui out so it knows what to set for the
                    //Type of Person radio buttons
                    string packageType = Mail.GetPackageType(package);

                    model.PackageType = packageType;
                }

            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ShippingViewModel model, string action)
        {
            //List<Package> packages = SessionHelper.GetShippingListFromSession();
            //List<Package> packages = GetPackageList();
            switch (model.ShippingType)
            {
                case "Standard":
                    Package package = new Package();
                    //LoadPackageFromForm(package, model);
                    GetAddressInformation(package, model);

                    model.Package = package;
                    if (action == "Save")
                    {
                        UpsertPackage(package);
                    }
                    break;
                case "Two Day":
                    TwoDayPackage twoDay = new TwoDayPackage();
                    LoadPackageFromForm(twoDay, model);
                    
                    model.Package = twoDay;
                    if (action == "Save")
                    {
                        UpsertPackage(twoDay);
                    }
                    break;
                case "Overnight":
                    OvernightPackage overnight = new OvernightPackage();
                    LoadPackageFromForm(overnight, model);
                    
                    model.Package = overnight;
                    if (action == "Save")
                    {
                        UpsertPackage(overnight);
                    }
                    break;
            }
            if (action == "Save")
            {
                //Put the current list of person back in session so that the PersonList page can use it
                //SessionHelper.SetShippingListInSession(packages);
                //SavePackageList(packages);

                //Go back to the PersonList page
                return RedirectToAction("ShippingList", "Shipping");
            }
            else
            {
                return View(model);
            }
            
        }
        //this method will accept an instance of Person, Student or Faculty for the person
        //parameter because they are all in the same inheritance heirarchy
        private void GetAddressInformation(Package package, ShippingViewModel model)
        {
            package.Sender.FirstName = model.Package.Sender.FirstName;
            package.Sender.LastName = model.Package.Sender.LastName;
            package.Sender.Address = model.Package.Sender.Address;
            package.Sender.City = model.Package.Sender.City;
            package.Sender.State = model.Package.Sender.State;
            package.Sender.ZipCode = model.Package.Sender.ZipCode;
            package.Sender.UniqueId = model.Package.Sender.UniqueId;
            package.Recipient.FirstName = model.Package.Recipient.FirstName;
            package.Recipient.LastName = model.Package.Recipient.LastName;
            package.Recipient.Address = model.Package.Recipient.Address;
            package.Recipient.City = model.Package.Recipient.City;
            package.Recipient.State = model.Package.Recipient.State;
            package.Recipient.ZipCode = model.Package.Recipient.ZipCode;
            package.Recipient.UniqueId = model.Package.Recipient.UniqueId;
            package.PackageUniqueId = model.Package.PackageUniqueId;
        }
        //If it's not there, add it. Otherwise find it and update it.
        private void UpsertPackage(Package package)
        {
            if (String.IsNullOrEmpty(package.PackageUniqueId))
            {
                //add mode, just add it to the list, after making sure it has a new unique id
                package.Sender.UniqueId = Guid.NewGuid().ToString();
                package.Recipient.UniqueId = Guid.NewGuid().ToString();
                package.PackageUniqueId = Guid.NewGuid().ToString();
                PackageDataAccess.InsertSender(package);
                PackageDataAccess.InsertRecipient(package);
                PackageDataAccess.InsertPackage(package);
                //packages.Add(package);

            }
            else
            {
                PackageDataAccess.UpdateSender(package);
                PackageDataAccess.UpdateRecipient(package);
                PackageDataAccess.UpdatePackage(package);
            }
        }
        public ActionResult PackageList(string sortDirection)
        {
            //create instane of the view model
            ShippingListViewModel model = new ShippingListViewModel();

            List<Package> packages = PackageDataAccess.GetPackageList();

            if (string.IsNullOrEmpty(sortDirection) == false)
            {
                if (sortDirection == "asc")
                {
                    packages.Sort();
                }
                else
                {
                    packages = packages.OrderByDescending(x => x.Sender.LastName).ToList();
                }
            }

            model.Packages.AddRange(packages);

            return View(model);
        }

        //private List<Package> GetPackageList()
        //{
        //    List<Package> packages = FileHelper.GetPackageList();

        //    return packages;
        //}

        private void SavePackageList(List<Package> packages)
        {
            FileHelper.SavePackageList(packages);
        }
        public ActionResult ShippingListHardcoded()
        {
            //create instane of the view model
            ShippingListViewModel model = new ShippingListViewModel();
            //create a person
            Package package = new Package();
            package.Sender.FirstName = "Janet";
            package.Sender.LastName = "Barkley";
            package.Sender.Address = "2389 Ninth St";
            package.Sender.City = "Boulder";
            package.Sender.State = "Colorado";
            package.Sender.ZipCode = "80524";
            package.Recipient.FirstName = "Jacob";
            package.Recipient.LastName = "Smith";
            package.Recipient.Address = "1455 55th Ave.";
            package.Recipient.City = "Boulder";
            package.Recipient.State = "Colorado";
            package.Recipient.ZipCode = "80524";

            //add the person to the view model
            model.Packages.Add(package);

            Package package2 = new Package();
            package2.Sender.FirstName = "Michael";
            package2.Sender.LastName = "Lee";
            package2.Sender.Address = "123 First Street";
            package2.Sender.City = "Ft Collins";
            package2.Sender.State = "Colorado";
            package2.Sender.ZipCode = "80524";
            package2.Recipient.FirstName = "Jane";
            package2.Recipient.LastName = "Smith";
            package2.Recipient.Address = "100 55th Ave.";
            package2.Recipient.City = "Boulder";
            package2.Recipient.State = "Colorado";
            package2.Recipient.ZipCode = "80524";

            //add the person to the view model
            model.Packages.Add(package2);






            return View(model);
        }
        public ActionResult ShippingList(string sortDirection)
        {
            ShippingListViewModel model = new ShippingListViewModel();
            //List<Package> packages = SessionHelper.GetShippingListFromSession();
            List<Package> packages = PackageDataAccess.GetPackageList();
            
            if (string.IsNullOrEmpty(sortDirection) == false)
            {
                if (sortDirection == "asc")
                {
                    
                    packages.Sort();
                }
                else
                {
                    packages = packages.OrderByDescending(x => x.Sender.LastName).ToList();
                }
                //SessionHelper.SetShippingListInSession(packages);
                //FileHelper.SavePackageList(packages);
            }
            model.Packages.AddRange(packages);
            return View(model);
        }
        //this method will accept an instance of Package, TwoDay or Overnight for the package
        //parameter because they are all in the same inheritance heirarchy
        private void LoadPackageFromForm(Package package, ShippingViewModel model)
        {
            package.CostPerOunce = model.Package.CostPerOunce;
            package.Weight = model.Package.Weight;
            package.Sender.UniqueId = model.Package.Sender.UniqueId;
            package.Sender.FirstName = model.Package.Sender.FirstName;
            package.Sender.LastName = model.Package.Sender.LastName;
            package.Sender.Address = model.Package.Sender.Address;
            package.Sender.City = model.Package.Sender.City;
            package.Sender.State = model.Package.Sender.State;
            package.Sender.ZipCode = model.Package.Sender.ZipCode;
            package.Recipient.FirstName = model.Package.Recipient.FirstName;
            package.Recipient.LastName = model.Package.Recipient.LastName;
            package.Recipient.Address = model.Package.Recipient.Address;
            package.Recipient.City = model.Package.Recipient.City;
            package.Recipient.State = model.Package.Recipient.State;
            package.Recipient.ZipCode = model.Package.Recipient.ZipCode;


        }
        
        public ActionResult Delete(string id)
        {
            PackageDataAccess.DeletePackage(id);
            PackageDataAccess.DeleteSender(id);
            PackageDataAccess.DeleteRecipient(id);

            //Go back to the PersonList page
            return RedirectToAction("ShippingList", "Shipping");
        }
    }
}