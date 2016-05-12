using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TwilioTester.Migrations
{
    public partial class emailcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "email", table: "Contacts");
        }
    }
}
