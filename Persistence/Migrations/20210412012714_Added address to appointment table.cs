using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Addedaddresstoappointmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppointmentName",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Appointments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Appointments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
