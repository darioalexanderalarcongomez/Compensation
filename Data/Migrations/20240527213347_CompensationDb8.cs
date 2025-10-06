using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "Event",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Event");
        }
    }
}
