using _Michael_Tinnin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace _Michael_Tinnin.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            FilesViewModel model = new FilesViewModel();
            model.FileContents = GetFileContents();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(FilesViewModel model)
        {
            //write to a file

            //MapPath translates a virtual directory like app_data to a physical location like 
            //G:\Asp.Net Class\Files & Serialization\File And Serialization Examples\App_Data
            string filePath = HttpContext.Server.MapPath("App_Data") + "/SampleFile.txt";

            StreamWriter writer = null;

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
                writer.WriteLine("Line Written at: " + DateTime.Now);

                //add a line for the actual file line 
                writer.WriteLine(model.FileLine);

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


            model.FileContents = GetFileContents();
            return View(model);
        }
        private string GetFileContents()
        {
            string filePath = HttpContext.Server.MapPath("App_Data") + "/SampleFile.txt";
            StringBuilder output = new StringBuilder();

            if (System.IO.File.Exists(filePath))
            {

                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    //as long as there is text to read 
                    while (streamReader.Peek() != -1)
                    {
                        //read one line
                        output.Append(streamReader.ReadLine());

                        //add some break tags so it looks ok on web
                        output.Append("</br>");
                    }

                    streamReader.Close();
                }
            }

            return output.ToString();
        }
    }
}