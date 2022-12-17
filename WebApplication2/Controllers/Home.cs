using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection("Data Source=C:\\Users\\mbare\\OneDrive\\Bureau\\framework\\2022 GL3 .NET Framework TP3 - SQLite database.db ; Integrated Security= True"))
                {
                    sqlcon.Open();
                    Debug.WriteLine("Conection opened ");

                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info ", sqlcon);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Debug.WriteLine("Data reader  returned " + reader.FieldCount + " Colums");
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["id"];
                                string first_name = (string)reader["first_name"];
                                string last_name = (string)reader["last_name"];
                                string email = (string)reader["email"];
                                //DateTime date_of_birth = (DateTime)reader["date_of_birth"];
                                string image = (string)reader["image"];
                                string country = (string)reader["country"];
                                Debug.WriteLine("ID :" + id + " First name :" + first_name + " Last name :" + last_name + " email :" + email + "Image :" + image + " Country :" + country);

                            }

                        }
                        else
                        {
                            Debug.WriteLine("reader returned 0 rows");
                        }
                    }



                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erreur :" + e.Message);
            }

            finally
            {
                Debug.WriteLine("End.");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}