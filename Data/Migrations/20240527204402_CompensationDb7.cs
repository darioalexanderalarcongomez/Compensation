using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Employee_Employee_Id1",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Fare_Fare_Id1",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Venues_Venues_Id1",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Employee_Id1",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Fare_Id1",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Venues_Id1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Employee_Id1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Fare_Id1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Venues_Id1",
                table: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Employee_Id",
                table: "Event",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Fare_Id",
                table: "Event",
                column: "Fare_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Venues_Id",
                table: "Event",
                column: "Venues_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Employee_Employee_Id",
                table: "Event",
                column: "Employee_Id",
                principalTable: "Employee",
                principalColumn: "Employee_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Fare_Fare_Id",
                table: "Event",
                column: "Fare_Id",
                principalTable: "Fare",
                principalColumn: "Fare_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Venues_Venues_Id",
                table: "Event",
                column: "Venues_Id",
                principalTable: "Venues",
                principalColumn: "Venues_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Employee_Employee_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Fare_Fare_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Venues_Venues_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Employee_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Fare_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Venues_Id",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Employee_Id1",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fare_Id1",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Venues_Id1",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Employee_Employee_Id1",
                table: "Event",
                column: "Employee_Id1",
                principalTable: "Employee",
                principalColumn: "Employee_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Fare_Fare_Id1",
                table: "Event",
                column: "Fare_Id1",
                principalTable: "Fare",
                principalColumn: "Fare_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Venues_Venues_Id1",
                table: "Event",
                column: "Venues_Id1",
                principalTable: "Venues",
                principalColumn: "Venues_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
