using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRO05_backend_riley_tanya_dani_levi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationForRender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5640), new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5640), new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 10, 52, 34, 177, DateTimeKind.Utc).AddTicks(5490));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690), new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 19, 12, 8, 4, 695, DateTimeKind.Utc).AddTicks(9430));
        }
    }
}
