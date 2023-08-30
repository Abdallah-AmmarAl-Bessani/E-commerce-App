using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class newSetupForDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Department_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Electric" },
                    { 2, "Houseware" },
                    { 3, "Food" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "ID", "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Screens" },
                    { 2, 1, "Fridges" },
                    { 3, 2, "Tables" },
                    { 4, 2, "Kitchen Tools" },
                    { 5, 3, "Meats" },
                    { 6, 3, "Food Stuff" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "DepartmentID", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Samsung", 350, 23 },
                    { 2, 1, "LG", 300, 40 },
                    { 3, 2, "Beko", 250, 50 },
                    { 4, 2, "Toshiba", 280, 40 },
                    { 5, 3, "4 Person lunch Table", 40, 100 },
                    { 6, 3, "8 Person lunch table", 70, 100 },
                    { 7, 4, "Teval Pan", 20, 45 },
                    { 8, 4, "Dishes", 15, 100 },
                    { 9, 5, "Sheep meat", 15, 110 },
                    { 10, 5, "Beef", 10, 80 },
                    { 11, 6, "Sunny frying oil", 10, 80 },
                    { 12, 6, "Durra Bean Box 500g", 1, 48 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_CategoryID",
                table: "Department",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DepartmentID",
                table: "Product",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
