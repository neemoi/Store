using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class СhanginTheTеablesAndPropertiesDeliveryPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "OrderId1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "OrderId",
                table: "deliveries");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "deliveries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "OrderId1",
                table: "payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "OrderId",
                table: "deliveries",
                column: "OrderId");
        }
    }
}
