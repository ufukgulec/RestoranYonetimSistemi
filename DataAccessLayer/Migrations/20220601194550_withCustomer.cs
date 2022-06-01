using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class withCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneOrders_Streets_StreetId",
                table: "PhoneOrders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PhoneOrders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PhoneOrders");

            migrationBuilder.RenameColumn(
                name: "StreetId",
                table: "PhoneOrders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneOrders_StreetId",
                table: "PhoneOrders",
                newName: "IX_PhoneOrders_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StreetId",
                table: "Customers",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneOrders_Customers_CustomerId",
                table: "PhoneOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneOrders_Customers_CustomerId",
                table: "PhoneOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "PhoneOrders",
                newName: "StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneOrders_CustomerId",
                table: "PhoneOrders",
                newName: "IX_PhoneOrders_StreetId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PhoneOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PhoneOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneOrders_Streets_StreetId",
                table: "PhoneOrders",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
