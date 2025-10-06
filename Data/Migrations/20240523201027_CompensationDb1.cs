using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fare",
                columns: table => new
                {
                    Fare_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fare_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fare", x => x.Fare_Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Venues_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Venues_Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Event_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description_Event = table.Column<string>(type: "varchar(200)", nullable: false),
                    ClockIn_Event = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ClockOut_Event = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Fare_Id = table.Column<int>(type: "int", nullable: false),
                    Fare_Id1 = table.Column<int>(type: "int", nullable: false),
                    Venues_Id = table.Column<int>(type: "int", nullable: false),
                    Venues_Id1 = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Event_Id);
                    table.ForeignKey(
                        name: "FK_Event_Employee_Employee_Id1",
                        column: x => x.Employee_Id1,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Fare_Fare_Id1",
                        column: x => x.Fare_Id1,
                        principalTable: "Fare",
                        principalColumn: "Fare_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Venues_Venues_Id1",
                        column: x => x.Venues_Id1,
                        principalTable: "Venues",
                        principalColumn: "Venues_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_Employee_Id1",
                table: "Event",
                column: "Employee_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Fare_Id1",
                table: "Event",
                column: "Fare_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Venues_Id1",
                table: "Event",
                column: "Venues_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Fare");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
