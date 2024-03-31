using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateAppointmentsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "day",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "dayAr",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dayEn",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "duration",
                table: "DoctorAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dayAr",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dayEn",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dayAr",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "dayEn",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "dayAr",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "dayEn",
                table: "Appointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "day",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "day",
                table: "Appointments",
                type: "datetime2",
                nullable: true);
        }
    }
}
