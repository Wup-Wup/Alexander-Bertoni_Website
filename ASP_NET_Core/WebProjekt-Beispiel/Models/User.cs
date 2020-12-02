using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekt_Beispiel.Models
{
    public class User : Controller
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool Remember { get; set; }

        public User() : this("", "", "", "","",false) { }
        public User(string firstname, string lastname, string email,string password,string passwordConfirm, bool remember)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this. Password= password;
            this.Remember = remember;
            this.PasswordConfirm = passwordConfirm;
        }

        public override string ToString()
        {
            return this.Firstname + " " + this.Lastname + " " + this.Email;
        }
    }
}
