using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TwilioTester.Migrations
{
    public partial class changeinttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "number",
                table: "Contacts",
                nullable: false);
        }
    }
}
