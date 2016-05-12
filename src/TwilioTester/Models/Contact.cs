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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string number { get; set;  }
        public string email { get; set; }
    }
}
