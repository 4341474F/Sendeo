using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderNo", "Name", "Phone", "Email", "Address", "OrderDate" },
                values: new object[,]
                {
                    {  "Order.1", "OrderDetails.1", "Sendeo Order 1", "1234567", "user1@sendeo.com", "Adress 1", new DateTime() },
                    {  "Order.2", "OrderDetails.2", "Sendeo Order 2", "1234567", "user2@sendeo.com", "Adress 2", new DateTime() },
                    {  "Order.3", "OrderDetails.3", "Sendeo Order 3", "1234567", "user3@sendeo.com", "Adress 3", new DateTime() },
                    {  "Order.4", "OrderDetails.4", "Sendeo Order 4", "1234567", "user4@sendeo.com", "Adress 4", new DateTime() },
                    {  "Order.5", "OrderDetails.5", "Sendeo Order 5", "1234567", "user5@sendeo.com", "Adress 5", new DateTime() }
                });
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { "Product.1", "Category3", "Description5", "ImageFile1", "Name1", 250m, 0 },
                    { "Product.2", "Category1", "Description3", "ImageFile1", "Name1", 200m, 0 },
                    { "Product.3", "Category2", "Description4", "ImageFile1", "Name1", 10m, 0 },
                    { "Product.4", "Category1", "Description1", "ImageFile1", "Name1", 100m, 0 },
                    { "Product.5", "Category2", "Description2", "ImageFile1", "Name1", 100m, 0 }
                });
            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderNo",
                        column: x => x.OrderNo,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderNo",
                table: "OrderDetails",
                column: "OrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderNo", "ProductId" },
                values: new object[,]
                {
                    { "OrderDetails.1", "Order.1", "Product.1"},
                    { "OrderDetails.2", "Order.2", "Product.2"},
                    { "OrderDetails.3", "Order.3", "Product.3"},
                    { "OrderDetails.4", "Order.4", "Product.4"},
                    { "OrderDetails.5", "Order.5", "Product.5"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
