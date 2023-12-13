using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "orderitems_ibfk_1",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "orderitems_ibfk_2",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "orders_ibfk_1",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "category",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "orderitems_ibfk_1",
                table: "orderitems",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "orderitems_ibfk_2",
                table: "orderitems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "orders_ibfk_1",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "orderitems_ibfk_1",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "orderitems_ibfk_2",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "orders_ibfk_1",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "category",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "orderitems_ibfk_1",
                table: "orderitems",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "orderitems_ibfk_2",
                table: "orderitems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "orders_ibfk_1",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
