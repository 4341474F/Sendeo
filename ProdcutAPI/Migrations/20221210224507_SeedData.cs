using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdcutAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "0fcd47f4-78db-4818-8de1-80d413dcfb9f");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "4fd87b0d-2cee-4816-85b4-bacde38039d9");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "638a0256-0be8-4035-aebd-81f9b51b1ace");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "671ee4f2-f4e5-49c6-978c-7a0883fbd491");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "864edab2-993d-4a2b-82f5-fad3dcc7f302");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { "155a117a-8702-457b-af80-b739f4f6238c", "Category2", "Description4", "ImageFile1", "Name1", 10m, 0 },
                    { "2e36494f-2baa-4e32-857d-f825264fb97a", "Category2", "Description2", "ImageFile1", "Name1", 100m, 0 },
                    { "440c6650-cfba-4a2d-9e86-14e0fcafd3db", "Category1", "Description3", "ImageFile1", "Name1", 200m, 0 },
                    { "b529d950-af8b-4f11-9fc5-4cd5c4b3ad91", "Category3", "Description5", "ImageFile1", "Name1", 250m, 0 },
                    { "fe9caa14-3e26-4e29-8a81-96b7bddda6ea", "Category1", "Description1", "ImageFile1", "Name1", 100m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "155a117a-8702-457b-af80-b739f4f6238c");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "2e36494f-2baa-4e32-857d-f825264fb97a");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "440c6650-cfba-4a2d-9e86-14e0fcafd3db");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "b529d950-af8b-4f11-9fc5-4cd5c4b3ad91");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "fe9caa14-3e26-4e29-8a81-96b7bddda6ea");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Product");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price" },
                values: new object[,]
                {
                    { "0fcd47f4-78db-4818-8de1-80d413dcfb9f", "Category2", "Description4", "ImageFile1", "Name1", 10m },
                    { "4fd87b0d-2cee-4816-85b4-bacde38039d9", "Category1", "Description1", "ImageFile1", "Name1", 100m },
                    { "638a0256-0be8-4035-aebd-81f9b51b1ace", "Category1", "Description3", "ImageFile1", "Name1", 200m },
                    { "671ee4f2-f4e5-49c6-978c-7a0883fbd491", "Category3", "Description5", "ImageFile1", "Name1", 250m },
                    { "864edab2-993d-4a2b-82f5-fad3dcc7f302", "Category2", "Description2", "ImageFile1", "Name1", 100m }
                });
        }
    }
}
