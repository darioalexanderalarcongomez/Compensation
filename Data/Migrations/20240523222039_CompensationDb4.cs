using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Event_EventsEvent_Id",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EventFare");

            migrationBuilder.DropTable(
                name: "EventVenues");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EventsEvent_Id",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EventsEvent_Id",
                table: "Employee");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EventsEvent_Id",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventFare",
                columns: table => new
                {
                    EventsEvent_Id = table.Column<int>(type: "int", nullable: false),
                    FaresFare_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFare", x => new { x.EventsEvent_Id, x.FaresFare_Id });
                    table.ForeignKey(
                        name: "FK_EventFare_Event_EventsEvent_Id",
                        column: x => x.EventsEvent_Id,
                        principalTable: "Event",
                        principalColumn: "Event_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFare_Fare_FaresFare_Id",
                        column: x => x.FaresFare_Id,
                        principalTable: "Fare",
                        principalColumn: "Fare_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVenues",
                columns: table => new
                {
                    EventsEvent_Id = table.Column<int>(type: "int", nullable: false),
                    Venues_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenues", x => new { x.EventsEvent_Id, x.Venues_Id });
                    table.ForeignKey(
                        name: "FK_EventVenues_Event_EventsEvent_Id",
                        column: x => x.EventsEvent_Id,
                        principalTable: "Event",
                        principalColumn: "Event_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVenues_Venues_Venues_Id",
                        column: x => x.Venues_Id,
                        principalTable: "Venues",
                        principalColumn: "Venues_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EventsEvent_Id",
                table: "Employee",
                column: "EventsEvent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventFare_FaresFare_Id",
                table: "EventFare",
                column: "FaresFare_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventVenues_Venues_Id",
                table: "EventVenues",
                column: "Venues_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Event_EventsEvent_Id",
                table: "Employee",
                column: "EventsEvent_Id",
                principalTable: "Event",
                principalColumn: "Event_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
