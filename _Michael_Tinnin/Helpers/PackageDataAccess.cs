using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using _Michael_Tinnin.Models;

namespace _Michael_Tinnin.Helpers
{
    public class PackageDataAccess
    {
        public static void InsertSender(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"INSERT INTO Sender_Mail(UniqueId, FirstName, LastName, Address, City, State, ZipCode)
                               VALUES(@UniqueId, @FirstName, @LastName, @Address, @City, @State, @ZipCode)";

                string packageType = Mail.GetPackageType(package);

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@UniqueId", package.Sender.UniqueId));
                    command.Parameters.Add(new SqlParameter("@FirstName", package.Sender.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", package.Sender.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", package.Sender.Address));
                    command.Parameters.Add(new SqlParameter("@City", package.Sender.City));
                    command.Parameters.Add(new SqlParameter("@State", package.Sender.State));
                    command.Parameters.Add(new SqlParameter("@ZipCode", package.Sender.ZipCode));
                    

                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void InsertRecipient(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"INSERT INTO Recipient_Mail(UniqueId, FirstName, LastName, Address, City, State, ZipCode)
                               VALUES(@UniqueId, @FirstName, @LastName, @Address, @City, @State, @ZipCode)";

                string packageType = Mail.GetPackageType(package);

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@UniqueId", package.Recipient.UniqueId));
                    command.Parameters.Add(new SqlParameter("@FirstName", package.Recipient.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", package.Recipient.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", package.Recipient.Address));
                    command.Parameters.Add(new SqlParameter("@City", package.Recipient.City));
                    command.Parameters.Add(new SqlParameter("@State", package.Recipient.State));
                    command.Parameters.Add(new SqlParameter("@ZipCode", package.Recipient.ZipCode));


                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void InsertPackage(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"INSERT INTO Package(PackageId, SenderId, RecipientId, Weight, CostPerOunce, Type)
                               VALUES(@PackageUniqueId, @SenderUniqueId, @RecipientUniqueId, @Weight, @CostPerOunce, @Type)";

                string packageType = Mail.GetPackageType(package);

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@PackageUniqueId", package.PackageUniqueId));
                    command.Parameters.Add(new SqlParameter("@SenderUniqueId", package.Sender.UniqueId));
                    command.Parameters.Add(new SqlParameter("@RecipientUniqueId", package.Recipient.UniqueId));
                    command.Parameters.Add(new SqlParameter("@Weight", package.Weight));
                    command.Parameters.Add(new SqlParameter("@CostPerOunce", package.CostPerOunce));
                    command.Parameters.Add(new SqlParameter("@Type", packageType));


                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void UpdateSender(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"UPDATE Sender_Mail SET FirstName = @FirstName, LastName = @LastName, 
                               Address = @Address, City = @City, State = @State, ZipCode = @ZipCode
                               
                               WHERE UniqueId = @UniqueId";

                string packageType = Mail.GetPackageType(package);

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@FirstName", package.Sender.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", package.Sender.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", package.Sender.Address));
                    command.Parameters.Add(new SqlParameter("@City", package.Sender.City));
                    command.Parameters.Add(new SqlParameter("@State", package.Sender.State));
                    command.Parameters.Add(new SqlParameter("@ZipCode", package.Sender.ZipCode));
                    command.Parameters.Add(new SqlParameter("@UniqueId", package.Sender.UniqueId));


                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void UpdateRecipient(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"UPDATE Recipient_Mail SET FirstName = @FirstName, LastName = @LastName, 
                               Address = @Address, City = @City, State = @State, ZipCode = @ZipCode
                               
                               WHERE UniqueId = @UniqueId";

                

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@FirstName", package.Recipient.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", package.Recipient.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", package.Recipient.Address));
                    command.Parameters.Add(new SqlParameter("@City", package.Recipient.City));
                    command.Parameters.Add(new SqlParameter("@State", package.Recipient.State));
                    command.Parameters.Add(new SqlParameter("@ZipCode", package.Recipient.ZipCode));
                    command.Parameters.Add(new SqlParameter("@UniqueId", package.Recipient.UniqueId));


                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void UpdatePackage(Package package)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"UPDATE Package SET Weight = @Weight, CostPerOunce = @CostPerOunce, Type = @Type
                             WHERE PackageId = @UniqueId";

                string packageType = Mail.GetPackageType(package);

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //fill up the parameters with the values from the package properties
                    command.Parameters.Add(new SqlParameter("@Weight", package.Weight));
                    command.Parameters.Add(new SqlParameter("@CostPerOunce", package.CostPerOunce));
                    command.Parameters.Add(new SqlParameter("@Type", packageType));
                    command.Parameters.Add(new SqlParameter("@UniqueId", package.PackageUniqueId));


                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void DeletePackage(string id)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"DELETE FROM Package
                               WHERE PackageId = @UniqueId";

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    command.Parameters.Add(new SqlParameter("@UniqueId", id));

                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void DeleteSender(string id)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"DELETE FROM Sender_Mail
                               WHERE UniqueId = @UniqueId";

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    command.Parameters.Add(new SqlParameter("@UniqueId", id));

                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static void DeleteRecipient(string id)
        {
            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                //@ is the sql server symbol for a variable
                //@UniqueId means that is a place holder for a value to be supplied later
                string sql = @"DELETE FROM Recipient_Mail
                               WHERE UniqueId = @UniqueId";

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    command.Parameters.Add(new SqlParameter("@UniqueId", id));

                    int rowsEffected = command.ExecuteNonQuery();
                }

                //Close the database
                dbConnection.Close();
            }
        }
        public static List<Package> GetPackageList()
        {
            List<Package> packages = new List<Package>();

            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"SELECT *
                               FROM Package";
                               

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    //A data reader is a class that runs the Sql command we have given it
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string type = reader.GetString(reader.GetOrdinal("Type"));
                        

                        switch (type)
                        {
                            case "Standard":
                                Package package = new Package();

                                //convert and map from sql server types and names to C# types and name
                                MapPackage(package, reader);
                                
                                packages.Add(package);
                                break;
                            case "Two Day":
                                TwoDayPackage twoDay = new TwoDayPackage();
                                MapPackage(twoDay, reader);
                                packages.Add(twoDay);
                                break;
                            case "Overnight":
                                OvernightPackage overnight = new OvernightPackage();
                                MapPackage(overnight, reader);
                                packages.Add(overnight);
                                break;
                        }
                    }
                }

                //Close the database
                dbConnection.Close();
            }

            return packages;
        }
        public static Package GetPackage(string id)
        {
            Package result = null;

            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"SELECT *
                               FROM Package
                               WHERE PackageId = @UniqueId";
                


                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                   command.Parameters.Add(new SqlParameter("@UniqueId", id));
                    //command.Parameters.Add(new SqlParameter("@PackageUniqueId", id));


                    //A data reader is a class that runs the Sql command we have given it
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string type = reader.GetString(reader.GetOrdinal("Type"));

                        switch (type)
                        {
                            case "Standard":
                                Package package = new Package();
                                MapPackage(package, reader);
                                result = package;
                                break;
                            case "Two Day":
                                TwoDayPackage student = new TwoDayPackage();
                                MapPackage(student, reader);
                                result = student;
                                break;
                            case "Overnight":
                                OvernightPackage faculty = new OvernightPackage();
                                MapPackage(faculty, reader);
                                result = faculty;
                                break;
                        }
                    }
                }

                //Close the database
                dbConnection.Close();
            }

            return result;
        }
        public static Mail GetSenderMail(string id)
        {
            
            Mail result = new Mail();

            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"SELECT *
                               FROM Sender_Mail
                               WHERE UniqueId = @UniqueId";

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    command.Parameters.Add(new SqlParameter("@UniqueId", id));

                    //A data reader is a class that runs the Sql command we have given it
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.UniqueId = reader["UniqueId"].ToString();
                        result.FirstName = reader["FirstName"].ToString();
                        result.LastName = reader["LastName"].ToString();
                        result.Address = reader["Address"].ToString();
                        result.City = reader["City"].ToString();
                        result.State = reader["State"].ToString();
                        result.ZipCode = reader["ZipCode"].ToString();

                    }
                }

                //Close the database
                dbConnection.Close();
            }

            return result;
            
        }
        public static Mail GetRecipientMail(string id)
        {

            Mail result = new Mail();

            //get a new connection to the database using the connection string stored in web.config
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"SELECT *
                               FROM Recipient_Mail
                               WHERE UniqueId = @UniqueId";

                //Open the database
                dbConnection.Open();

                //Get a Sql Command object to hold the SQL query we want to run
                using (SqlCommand command = new SqlCommand(sql, dbConnection))
                {
                    command.Parameters.Add(new SqlParameter("@UniqueId", id));

                    //A data reader is a class that runs the Sql command we have given it
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.UniqueId = reader["UniqueId"].ToString();
                        result.FirstName = reader["FirstName"].ToString();
                        result.LastName = reader["LastName"].ToString();
                        result.Address = reader["Address"].ToString();
                        result.City = reader["City"].ToString();
                        result.State = reader["State"].ToString();
                        result.ZipCode = reader["ZipCode"].ToString();

                    }
                }

                //Close the database
                dbConnection.Close();
            }

            return result;

        }





        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MailingListConnectionString"].ConnectionString;
        }
        
        private static void MapPackage(Package package, SqlDataReader reader)
        {
            
            //package.PackageUniqueId = reader.GetGuid(reader.GetOrdinal("PackageId")).ToString();
            package.PackageUniqueId = reader.GetString(reader.GetOrdinal("PackageId"));
            //get uniqueId for Sender
            string senderUniqueId = reader.GetString(reader.GetOrdinal("SenderId"));
            //Get the sender SenderPerson and attach to this package
            package.Sender = GetSenderMail(senderUniqueId);
            //get uniqueId for Recipient
            string destinationUniqueId = reader.GetString(reader.GetOrdinal("RecipientId"));
            //Fetch the Recipient Person and attach to package
            package.Recipient = GetRecipientMail(destinationUniqueId);
            package.Weight = reader.GetInt32(reader.GetOrdinal("Weight"));
            package.CostPerOunce = reader.GetInt32(reader.GetOrdinal("CostPerOunce"));
        }
    }
}