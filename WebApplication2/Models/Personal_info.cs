using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplication2.Models
{
    public class Personal_info
    {
        private static Personal_info p_info = new Personal_info();
        private Personal_info() { }


        public static Personal_info getInstance()
        {
            return p_info;
        }
        public List<Person> GetAllPerson()
        {
            Debug.WriteLine("opening");
            List<Person> Persons = new List<Person>();


            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection("Data Source=C:\\Users\\mbare\\OneDrive\\Bureau\\framework\\2022 GL3 .NET Framework TP3 - SQLite database.db ; Integrated Security= True"))
                {
                    sqlcon.Open();
                    Debug.WriteLine("connection opened");
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info ", sqlcon);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Debug.WriteLine("Data reader  returned " + reader.FieldCount + " Colums");
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["id"];
                                string firstName = (string)reader["first_name"];
                                string lastName = (string)reader["last_name"];
                                string email = (string)reader["email"];
                                //DateTime date_of_birth = (DateTime)reader["date_of_birth"];
                                string image = (string)reader["image"];
                                string country = (string)reader["country"];
                                Persons.Add(new Person(id, firstName, lastName, email, image, country));
                                //    Debug.WriteLine("ID :" + id + " First name :" + first_name + " Last name :" + last_name + " email :" + email + "Image :" + image + " Country :" + country);

                            }

                        }
                        else
                        {
                            Debug.WriteLine("reader returned 0 rows");
                        }
                    }
                }
             


            }
            catch (Exception ex)
            {
                Debug.WriteLine("exception : " + ex.Message);
            }
            return Persons;
        }
        public Person GetPerson(int id)
        {
            Debug.WriteLine("opening");
            


            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection("Data Source=C:\\Users\\mbare\\OneDrive\\Bureau\\framework\\2022 GL3 .NET Framework TP3 - SQLite database.db ; Integrated Security= True"))
                {
                    sqlcon.Open();
                    Debug.WriteLine("connection opened");
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info WHERE id=" + id + " LIMIT 1;", sqlcon);
                    using (SQLiteDataReader datareader = command.ExecuteReader())
                    {
                        Debug.WriteLine("dataReader returned " + datareader.FieldCount + " Columns");
                        if (datareader.HasRows)
                        {
                            Person p = new Person();
                            while (datareader.Read())
                            {
                                // reading one record of the table
                                int i = (int)datareader["id"];
                                string firstName = (string)datareader["first_name"];
                                string lastName = (string)datareader["last_name"];
                                string email = (string)datareader["email"];
                            //    DateTime birthday = DateTime.Now;
                                string image = (string)datareader["image"];
                                string country = (string)datareader["country"];
                                p.id = i;
                                p.firstName = firstName;
                                p.lastName = lastName;
                                p.email = email;
                            //    p.birthday = birthday;
                                p.image = image;
                                p.country = country;
                            //    Debug.WriteLine("ID :" + id + " First name :" + firstName + " Last name :" + lastName + " email :" + email + "Image :" + image + " Country :" + country);

                            }
                            return p;
                        }
                        else
                        {
                            Debug.WriteLine("DataReader returned 0 rows ");
                            return null;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("exception : " + ex.Message);
                return null;
            }
            
            
        }
    }
}
