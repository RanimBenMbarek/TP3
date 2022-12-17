using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    //    public DateTime birthday { get; set; }
        public string image { get; set; }
        public string country { get; set; }
        public Person(int id, string firstName, string lastName, string email, string image, string country)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
           // this.birthday = birthday;
            this.image = image;
            this.country = country;
        }
        public Person() { }

    }
}
