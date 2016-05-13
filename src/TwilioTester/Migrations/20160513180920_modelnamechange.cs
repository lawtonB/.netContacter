using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TwilioTester.Migrations
{
    public partial class modelnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Contacts",
                newName: "Number");
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Contacts",
                newName: "LastName");
            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Contacts",
                newName: "FirstName");
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contacts",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Contacts",
                newName: "number");
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Contacts",
                newName: "lastName");
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Contacts",
                newName: "firstName");
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "email");
        }
    }
}
