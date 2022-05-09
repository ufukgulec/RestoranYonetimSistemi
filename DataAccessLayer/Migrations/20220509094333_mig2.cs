using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableOrderId",
                table: "TableOrdersDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffRoleId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneOrderId",
                table: "PhoneOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableOrdersDetails_ProductId",
                table: "TableOrdersDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TableOrdersDetails_TableOrderId",
                table: "TableOrdersDetails",
                column: "TableOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TableOrders_StaffId",
                table: "TableOrders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TableOrders_TableId",
                table: "TableOrders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_DistrictId",
                table: "Streets",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffRoleId",
                table: "Staffs",
                column: "StaffRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneOrders_StreetId",
                table: "PhoneOrders",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneOrderDetails_PhoneOrderId",
                table: "PhoneOrderDetails",
                column: "PhoneOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneOrderDetails_ProductId",
                table: "PhoneOrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneOrderDetails_PhoneOrders_PhoneOrderId",
                table: "PhoneOrderDetails",
                column: "PhoneOrderId",
                principalTable: "PhoneOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneOrderDetails_Products_ProductId",
                table: "PhoneOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneOrders_Streets_StreetId",
                table: "PhoneOrders",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffsRoles_StaffRoleId",
                table: "Staffs",
                column: "StaffRoleId",
                principalTable: "StaffsRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Districts_DistrictId",
                table: "Streets",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableOrders_Staffs_StaffId",
                table: "TableOrders",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableOrders_Tables_TableId",
                table: "TableOrders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableOrdersDetails_Products_ProductId",
                table: "TableOrdersDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableOrdersDetails_TableOrders_TableOrderId",
                table: "TableOrdersDetails",
                column: "TableOrderId",
                principalTable: "TableOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneOrderDetails_PhoneOrders_PhoneOrderId",
                table: "PhoneOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneOrderDetails_Products_ProductId",
                table: "PhoneOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneOrders_Streets_StreetId",
                table: "PhoneOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffsRoles_StaffRoleId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Districts_DistrictId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_TableOrders_Staffs_StaffId",
                table: "TableOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TableOrders_Tables_TableId",
                table: "TableOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TableOrdersDetails_Products_ProductId",
                table: "TableOrdersDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TableOrdersDetails_TableOrders_TableOrderId",
                table: "TableOrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_TableOrdersDetails_ProductId",
                table: "TableOrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_TableOrdersDetails_TableOrderId",
                table: "TableOrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_TableOrders_StaffId",
                table: "TableOrders");

            migrationBuilder.DropIndex(
                name: "IX_TableOrders_TableId",
                table: "TableOrders");

            migrationBuilder.DropIndex(
                name: "IX_Streets_DistrictId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_StaffRoleId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_PhoneOrders_StreetId",
                table: "PhoneOrders");

            migrationBuilder.DropIndex(
                name: "IX_PhoneOrderDetails_PhoneOrderId",
                table: "PhoneOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_PhoneOrderDetails_ProductId",
                table: "PhoneOrderDetails");

            migrationBuilder.DropColumn(
                name: "TableOrderId",
                table: "TableOrdersDetails");

            migrationBuilder.DropColumn(
                name: "StaffRoleId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "PhoneOrderId",
                table: "PhoneOrderDetails");
        }
    }
}
