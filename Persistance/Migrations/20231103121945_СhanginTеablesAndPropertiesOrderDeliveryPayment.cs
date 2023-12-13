using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class СhanginTеablesAndPropertiesOrderDeliveryPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "deliveries_ibfk_1",
                table: "deliveries");

            migrationBuilder.DropForeignKey(
                name: "payments_ibfk_1",
                table: "payments");

            migrationBuilder.AddColumn<int>(
                name: "DeliverId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliverId",
                table: "orders",
                column: "DeliverId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_PaymentId",
                table: "orders",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "orders_delivery_ibfk",
                table: "orders",
                column: "DeliverId",
                principalTable: "deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "orders_payment_ibfk",
                table: "orders",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "orders_delivery_ibfk",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "orders_payment_ibfk",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_DeliverId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_PaymentId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeliverId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "deliveries_ibfk_1",
                table: "deliveries",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "payments_ibfk_1",
                table: "payments",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }
    }
}
