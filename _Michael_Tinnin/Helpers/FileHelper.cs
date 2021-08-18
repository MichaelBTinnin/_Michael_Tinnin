using _Michael_Tinnin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _Michael_Tinnin.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Writes to log file
        /// </summary>
        /// <param name="label">Label for the error message</param>
        /// <param name="message">Full Error Message</param>
        public static void WriteToLogFile(string label, string message)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data") + "/ErrorsFile.txt";

            StreamWriter writer = null;

            string logMessage = string.Format("{0}: {1}", label, message);

            try
            {
                //if the file is not there, create it
                if (!System.IO.File.Exists(filePath))
                {
                    writer = new StreamWriter(filePath);
                }
                else
                {
                    //if the file exists, just add a new line at the bottom
                    writer = System.IO.File.AppendText(filePath);
                }

                // add a line for the time stamp 
                writer.WriteLine("Error Occured at: " + DateTime.Now);

                //add a line for the actual file line 
                writer.WriteLine(logMessage);

                //write an empty line as white space
                writer.WriteLine();
            }
            finally
            {
                //always close files, bad things can happen if you leave them open
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        
        /// <summary>
        /// Gets Package List from correct file.
       
        /// </summary>
        /// <returns>List<Package></returns>
        public static List<Package> GetPackageList()
        {
            List<Package> packages = new List<Package>();

            
                    packages = GetPackageListFromJsonFile();
                    
            return packages;
        }
        /// <summary>
        /// Saves Package List to the file.
        /// </summary>
        /// <param name="packages">List<Package> to persist</Package></param>

        public static void SavePackageList(List<Package> packages)
        {
           
                    SavePackageListToJsonFile(packages);
                    
        }
        /// <summary>
        /// Opens the JSON file with the persisited Person List and deserializes it 
        /// into a List<Person>
        /// </summary>
        /// <returns>List<Person></returns>
        private static void SavePackageListToJsonFile(List<Package> packages)
        {
            //Create an instance of PersonData
            PackageData packageData = new PackageData();

            //Copy the list of persons over to it
            foreach (Package item in packages)
            {
                packageData.Packages.Add(item);
            }

            string filePath = HttpContext.Current.Server.MapPath("~/App_Data") + "\\PackageList.json";

            

            //TypeNameHandling is required to get the inheritance right since our list of packages
            //has multiple types in it
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(packageData, settings);

            //Save our json string as a file on disk
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(json);
            }
        }
        /// <summary>
        /// Saves the package list to a JSON file after serializing the Package List to JSON.
        /// </summary>
        /// <param name="packages">List<Package></param>
        private static List<Package> GetPackageListFromJsonFile()
        {
            PackageData packageData = new PackageData();

            string filePath = HttpContext.Current.Server.MapPath("~/App_Data") + "\\PackageList.json";

            //Look for a file
            if (File.Exists(filePath))
            {
                //Read the json file back in
                string json;
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    json = streamReader.ReadToEnd();
                }

                //required to preserve the correct inherited types
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                //Get an instance of PackageList by calling Deserialize
                packageData = JsonConvert.DeserializeObject<PackageData>(json, settings);
            }

            //if there is no existing file, we are just returning an empty list of packagess
            return packageData.Packages;
        }

    }
}