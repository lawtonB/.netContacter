using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TwilioTester.Migrations
{
    public partial class firstNamelastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "name", table: "Contacts");
            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Contacts",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "firstName", table: "Contacts");
            migrationBuilder.DropColumn(name: "lastName", table: "Contacts");
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Contacts",
                nullable: true);
        }
    }
}
