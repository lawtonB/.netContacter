using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TwilioTester.Models;

namespace TwilioTester.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160511231049_changeinttostring")]
    partial class changeinttostring
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

                    b.Property<string>("name");

                    b.Property<string>("number");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Contacts");
                });
        }
    }
}
