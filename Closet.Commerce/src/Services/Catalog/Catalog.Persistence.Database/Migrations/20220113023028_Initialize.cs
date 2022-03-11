using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "description for product 1", "product 1", 123m },
                    { 2, "description for product 2", "product 2", 517m },
                    { 3, "description for product 3", "product 3", 461m },
                    { 4, "description for product 4", "product 4", 868m },
                    { 5, "description for product 5", "product 5", 297m },
                    { 6, "description for product 6", "product 6", 618m },
                    { 7, "description for product 7", "product 7", 668m },
                    { 8, "description for product 8", "product 8", 520m },
                    { 9, "description for product 9", "product 9", 770m },
                    { 10, "description for product 10", "product 10", 590m },
                    { 11, "description for product 11", "product 11", 549m },
                    { 12, "description for product 12", "product 12", 355m },
                    { 13, "description for product 13", "product 13", 632m },
                    { 14, "description for product 14", "product 14", 179m },
                    { 15, "description for product 15", "product 15", 559m },
                    { 16, "description for product 16", "product 16", 869m },
                    { 17, "description for product 17", "product 17", 857m },
                    { 18, "description for product 18", "product 18", 545m },
                    { 19, "description for product 19", "product 19", 710m },
                    { 20, "description for product 20", "product 20", 790m },
                    { 21, "description for product 21", "product 21", 604m },
                    { 22, "description for product 22", "product 22", 363m },
                    { 23, "description for product 23", "product 23", 964m },
                    { 24, "description for product 24", "product 24", 361m },
                    { 25, "description for product 25", "product 25", 748m },
                    { 26, "description for product 26", "product 26", 478m },
                    { 27, "description for product 27", "product 27", 482m },
                    { 28, "description for product 28", "product 28", 219m },
                    { 29, "description for product 29", "product 29", 462m },
                    { 30, "description for product 30", "product 30", 787m },
                    { 31, "description for product 31", "product 31", 217m },
                    { 32, "description for product 32", "product 32", 764m },
                    { 33, "description for product 33", "product 33", 640m },
                    { 34, "description for product 34", "product 34", 444m },
                    { 35, "description for product 35", "product 35", 103m },
                    { 36, "description for product 36", "product 36", 408m },
                    { 37, "description for product 37", "product 37", 407m },
                    { 38, "description for product 38", "product 38", 697m },
                    { 39, "description for product 39", "product 39", 685m },
                    { 40, "description for product 40", "product 40", 777m },
                    { 41, "description for product 41", "product 41", 717m },
                    { 42, "description for product 42", "product 42", 591m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 43, "description for product 43", "product 43", 514m },
                    { 44, "description for product 44", "product 44", 759m },
                    { 45, "description for product 45", "product 45", 970m },
                    { 46, "description for product 46", "product 46", 595m },
                    { 47, "description for product 47", "product 47", 980m },
                    { 48, "description for product 48", "product 48", 164m },
                    { 49, "description for product 49", "product 49", 701m },
                    { 50, "description for product 50", "product 50", 321m },
                    { 51, "description for product 51", "product 51", 780m },
                    { 52, "description for product 52", "product 52", 119m },
                    { 53, "description for product 53", "product 53", 619m },
                    { 54, "description for product 54", "product 54", 686m },
                    { 55, "description for product 55", "product 55", 356m },
                    { 56, "description for product 56", "product 56", 722m },
                    { 57, "description for product 57", "product 57", 600m },
                    { 58, "description for product 58", "product 58", 776m },
                    { 59, "description for product 59", "product 59", 781m },
                    { 60, "description for product 60", "product 60", 475m },
                    { 61, "description for product 61", "product 61", 177m },
                    { 62, "description for product 62", "product 62", 504m },
                    { 63, "description for product 63", "product 63", 458m },
                    { 64, "description for product 64", "product 64", 296m },
                    { 65, "description for product 65", "product 65", 607m },
                    { 66, "description for product 66", "product 66", 341m },
                    { 67, "description for product 67", "product 67", 568m },
                    { 68, "description for product 68", "product 68", 510m },
                    { 69, "description for product 69", "product 69", 382m },
                    { 70, "description for product 70", "product 70", 622m },
                    { 71, "description for product 71", "product 71", 925m },
                    { 72, "description for product 72", "product 72", 798m },
                    { 73, "description for product 73", "product 73", 714m },
                    { 74, "description for product 74", "product 74", 364m },
                    { 75, "description for product 75", "product 75", 948m },
                    { 76, "description for product 76", "product 76", 347m },
                    { 77, "description for product 77", "product 77", 267m },
                    { 78, "description for product 78", "product 78", 531m },
                    { 79, "description for product 79", "product 79", 526m },
                    { 80, "description for product 80", "product 80", 340m },
                    { 81, "description for product 81", "product 81", 349m },
                    { 82, "description for product 82", "product 82", 362m },
                    { 83, "description for product 83", "product 83", 147m },
                    { 84, "description for product 84", "product 84", 300m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 85, "description for product 85", "product 85", 133m },
                    { 86, "description for product 86", "product 86", 391m },
                    { 87, "description for product 87", "product 87", 718m },
                    { 88, "description for product 88", "product 88", 248m },
                    { 89, "description for product 89", "product 89", 852m },
                    { 90, "description for product 90", "product 90", 379m },
                    { 91, "description for product 91", "product 91", 772m },
                    { 92, "description for product 92", "product 92", 495m },
                    { 93, "description for product 93", "product 93", 828m },
                    { 94, "description for product 94", "product 94", 773m },
                    { 95, "description for product 95", "product 95", 652m },
                    { 96, "description for product 96", "product 96", 620m },
                    { 97, "description for product 97", "product 97", 382m },
                    { 98, "description for product 98", "product 98", 298m },
                    { 99, "description for product 99", "product 99", 983m },
                    { 100, "description for product 100", "product 100", 306m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 49 },
                    { 2, 2, 43 },
                    { 3, 3, 30 },
                    { 4, 4, 67 },
                    { 5, 5, 57 },
                    { 6, 6, 59 },
                    { 7, 7, 53 },
                    { 8, 8, 26 },
                    { 9, 9, 26 },
                    { 10, 10, 92 },
                    { 11, 11, 73 },
                    { 12, 12, 43 },
                    { 13, 13, 73 },
                    { 14, 14, 33 },
                    { 15, 15, 61 },
                    { 16, 16, 65 },
                    { 17, 17, 29 },
                    { 18, 18, 85 },
                    { 19, 19, 63 },
                    { 20, 20, 58 },
                    { 21, 21, 60 },
                    { 22, 22, 3 },
                    { 23, 23, 71 },
                    { 24, 24, 35 },
                    { 25, 25, 68 },
                    { 26, 26, 54 },
                    { 27, 27, 95 },
                    { 28, 28, 23 },
                    { 29, 29, 73 },
                    { 30, 30, 46 },
                    { 31, 31, 96 },
                    { 32, 32, 37 },
                    { 33, 33, 73 },
                    { 34, 34, 3 },
                    { 35, 35, 77 },
                    { 36, 36, 75 },
                    { 37, 37, 9 },
                    { 38, 38, 22 },
                    { 39, 39, 58 },
                    { 40, 40, 32 },
                    { 41, 41, 10 },
                    { 42, 42, 61 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 43, 43, 5 },
                    { 44, 44, 96 },
                    { 45, 45, 83 },
                    { 46, 46, 68 },
                    { 47, 47, 2 },
                    { 48, 48, 34 },
                    { 49, 49, 44 },
                    { 50, 50, 18 },
                    { 51, 51, 38 },
                    { 52, 52, 84 },
                    { 53, 53, 2 },
                    { 54, 54, 35 },
                    { 55, 55, 74 },
                    { 56, 56, 74 },
                    { 57, 57, 54 },
                    { 58, 58, 1 },
                    { 59, 59, 10 },
                    { 60, 60, 71 },
                    { 61, 61, 24 },
                    { 62, 62, 18 },
                    { 63, 63, 78 },
                    { 64, 64, 34 },
                    { 65, 65, 14 },
                    { 66, 66, 87 },
                    { 67, 67, 92 },
                    { 68, 68, 22 },
                    { 69, 69, 15 },
                    { 70, 70, 95 },
                    { 71, 71, 41 },
                    { 72, 72, 21 },
                    { 73, 73, 55 },
                    { 74, 74, 29 },
                    { 75, 75, 51 },
                    { 76, 76, 81 },
                    { 77, 77, 6 },
                    { 78, 78, 69 },
                    { 79, 79, 20 },
                    { 80, 80, 75 },
                    { 81, 81, 66 },
                    { 82, 82, 14 },
                    { 83, 83, 93 },
                    { 84, 84, 93 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 85, 85, 3 },
                    { 86, 86, 82 },
                    { 87, 87, 26 },
                    { 88, 88, 53 },
                    { 89, 89, 93 },
                    { 90, 90, 39 },
                    { 91, 91, 30 },
                    { 92, 92, 43 },
                    { 93, 93, 9 },
                    { 94, 94, 50 },
                    { 95, 95, 86 },
                    { 96, 96, 2 },
                    { 97, 97, 25 },
                    { 98, 98, 47 },
                    { 99, 99, 23 },
                    { 100, 100, 88 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
