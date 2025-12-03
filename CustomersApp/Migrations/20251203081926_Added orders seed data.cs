using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomersApp.Migrations
{
    /// <inheritdoc />
    public partial class Addedordersseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "PriceTotal" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1500m },
                    { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2500m },
                    { 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3500m },
                    { 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4500m },
                    { 5, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Orders");
        }
    }
}
