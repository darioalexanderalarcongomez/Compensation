using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Venues_Venues_Id",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.RenameColumn(
                name: "Venues_Id",
                table: "Event",
                newName: "Venue_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Venues_Id",
                table: "Event",
                newName: "IX_Event_Venue_Id");

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Venue_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Venue_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Venue_Venue_Id",
                table: "Event",
                column: "Venue_Id",
                principalTable: "Venue",
                principalColumn: "Venue_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Venue_Venue_Id",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.RenameColumn(
                name: "Venue_Id",
                table: "Event",
                newName: "Venues_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Venue_Id",
                table: "Event",
                newName: "IX_Event_Venues_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Venues_Venues_Id",
                table: "Event",
                column: "Venues_Id",
                principalTable: "Venues",
                principalColumn: "Venues_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
