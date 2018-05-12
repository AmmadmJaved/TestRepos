using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Migrations
{
    public partial class AddCNICFieldinPhysicianAndPatientUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNIC",
                table: "Physicians",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNIC",
                table: "PatientUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNIC",
                table: "Physicians");

            migrationBuilder.DropColumn(
                name: "CNIC",
                table: "PatientUsers");
        }
    }
}
