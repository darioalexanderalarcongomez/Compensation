using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compensation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompensationDb13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePayment",
                columns: table => new
                {
                    TypePayment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePayment", x => x.TypePayment_Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePayment_Id = table.Column<int>(type: "int", nullable: false),
                    Event_Id = table.Column<int>(type: "int", nullable: false),
                    PaymentOrder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payment_Event_Event_Id",
                        column: x => x.Event_Id,
                        principalTable: "Event",
                        principalColumn: "Event_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_TypePayment_TypePayment_Id",
                        column: x => x.TypePayment_Id,
                        principalTable: "TypePayment",
                        principalColumn: "TypePayment_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Event_Id",
                table: "Payment",
                column: "Event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TypePayment_Id",
                table: "Payment",
                column: "TypePayment_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "TypePayment");
        }
    }
}
