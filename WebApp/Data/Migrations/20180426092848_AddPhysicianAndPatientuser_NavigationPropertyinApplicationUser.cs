using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Migrations
{
    public partial class AddPhysicianAndPatientuser_NavigationPropertyinApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Physicians",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PatientUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Physicians_ApplicationUserId",
                table: "Physicians",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientUsers_ApplicationUserId",
                table: "PatientUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientUsers_AspNetUsers_ApplicationUserId",
                table: "PatientUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Physicians_AspNetUsers_ApplicationUserId",
                table: "Physicians",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientUsers_AspNetUsers_ApplicationUserId",
                table: "PatientUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Physicians_AspNetUsers_ApplicationUserId",
                table: "Physicians");

            migrationBuilder.DropIndex(
                name: "IX_Physicians_ApplicationUserId",
                table: "Physicians");

            migrationBuilder.DropIndex(
                name: "IX_PatientUsers_ApplicationUserId",
                table: "PatientUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Physicians");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PatientUsers");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
