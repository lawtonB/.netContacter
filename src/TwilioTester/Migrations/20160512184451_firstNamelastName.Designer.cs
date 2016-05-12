using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TwilioTester.Models;

namespace TwilioTester.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160512184451_firstNamelastName")]
    partial class firstNamelastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TwilioTester.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("number");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Contacts");
                });
        }
    }
}
