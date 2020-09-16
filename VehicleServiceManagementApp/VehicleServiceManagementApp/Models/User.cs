using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManagementApp.Models
{
    class User
    {
        private String userId;
        private String firstName;
        private String lastName;
        private String email;
        private String password;
        private String designation;

        public User()
        {
        }

        public User(string firstName, string lastName, string email, string password, string designation)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.designation = designation;
        }

        public User(string userId,string firstName, string lastName, string email, string password, string designation )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Designation = designation;
            UserId = userId;
           
        }

        public string UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Designation { get => designation; set => designation = value; }
    }
}
