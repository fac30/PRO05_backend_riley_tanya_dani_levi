using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRO05_backend_riley_tanya_dani_levi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9430), "john.doe@example.com", "Foodie123", "John Doe" },
                    { 2, new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9430), "jane.smith@example.com", "Burgers345", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "CreatedAt", "Description", "Ingredients", "IsPublic", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), "A classic Italian pasta dish.", "Spaghetti, minced beef, tomato sauce, onions, garlic", true, "Spaghetti Bolognese", new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), 1 },
                    { 2, 15, new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), "A quick and healthy stir fry.", "Mixed vegetables, soy sauce, garlic, ginger", true, "Vegetable Stir Fry", new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
