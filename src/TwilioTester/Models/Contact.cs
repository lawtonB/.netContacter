using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwilioTester.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set;  }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string number, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            Email = email;
        }

        public Contact() { }
    }  
}
