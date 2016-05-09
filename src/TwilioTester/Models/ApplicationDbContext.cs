using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace TwilioTester.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TwilioDatabase;integrated security = True");
        }
    }
}
