using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parkapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Category = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    State = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Visitors = table.Column<int>(type: "int", nullable: false),
                    EstDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Area", "Category", "EstDate", "Latitude", "Longitude", "Name", "State", "Visitors" },
                values: new object[] { 1, 4926.0799999999999, "National", new DateTime(1919, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.060000000000002, -112.14, "Grand Canyon", "Arizona", 2897098 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
