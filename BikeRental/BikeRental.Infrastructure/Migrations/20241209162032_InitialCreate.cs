using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CostPerPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.SerialNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customesrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customesrs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BikeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Customesrs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customesrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "SerialNumber", "Color", "CostPerPrice", "Model", "Type" },
                values: new object[,]
                {
                    { 1, "Red", 1500m, "X-Trail 500", 1 },
                    { 2, "Blue", 1000m, "EasyRide 200", 2 },
                    { 3, "Black", 2000m, "Speedster 3000", 3 },
                    { 4, "Green", 3000m, "Racer Pro 9000", 3 },
                    { 5, "Yellow", 1200m, "RockClimber X", 1 },
                    { 6, "White", 4000m, "City Explorer", 2 }
                });

            migrationBuilder.InsertData(
                table: "Customesrs",
                columns: new[] { "Id", "BirthDate", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 5, 20), "Тест Тестов", "88005553535" },
                    { 2, new DateOnly(1985, 3, 15), "Дима Нова", "88005553530" },
                    { 3, new DateOnly(2000, 12, 1), "Иероним Карл Фридрих фон Мюнхгаузен", "718005553535" },
                    { 4, new DateOnly(1995, 7, 15), "Alice Johnson", "555-123-9876" },
                    { 5, new DateOnly(1992, 11, 25), "Chris Evans", "444-321-8765" },
                    { 6, new DateOnly(1988, 2, 5), "Emma Wilson", "333-987-6543" }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BikeId", "CustomerId", "End", "Start" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 12, 9, 21, 20, 32, 149, DateTimeKind.Local).AddTicks(2253), new DateTime(2024, 12, 9, 17, 20, 32, 149, DateTimeKind.Local).AddTicks(2252) },
                    { 2, 2, 2, new DateTime(2024, 12, 9, 22, 20, 32, 149, DateTimeKind.Local).AddTicks(2262), new DateTime(2024, 12, 9, 18, 20, 32, 149, DateTimeKind.Local).AddTicks(2261) },
                    { 3, 3, 3, new DateTime(2024, 12, 9, 20, 20, 32, 149, DateTimeKind.Local).AddTicks(2265), new DateTime(2024, 12, 9, 16, 20, 32, 149, DateTimeKind.Local).AddTicks(2264) },
                    { 4, 4, 4, new DateTime(2024, 12, 9, 23, 20, 32, 149, DateTimeKind.Local).AddTicks(2268), new DateTime(2024, 12, 9, 15, 20, 32, 149, DateTimeKind.Local).AddTicks(2267) },
                    { 5, 5, 5, new DateTime(2024, 12, 10, 1, 20, 32, 149, DateTimeKind.Local).AddTicks(2271), new DateTime(2024, 12, 9, 17, 20, 32, 149, DateTimeKind.Local).AddTicks(2270) },
                    { 6, 6, 6, new DateTime(2024, 12, 10, 0, 20, 32, 149, DateTimeKind.Local).AddTicks(2275), new DateTime(2024, 12, 9, 18, 20, 32, 149, DateTimeKind.Local).AddTicks(2274) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BikeId",
                table: "Rents",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Customesrs");
        }
    }
}
