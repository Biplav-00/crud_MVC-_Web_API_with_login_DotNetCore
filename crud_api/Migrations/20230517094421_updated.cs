using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_api.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Person_tbl_Device_device_Id1",
                table: "tbl_Person");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Person_device_Id1",
                table: "tbl_Person");

            migrationBuilder.DropColumn(
                name: "device_Id",
                table: "tbl_Person");

            migrationBuilder.DropColumn(
                name: "device_Id1",
                table: "tbl_Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "device_Id",
                table: "tbl_Person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "device_Id1",
                table: "tbl_Person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Person_device_Id1",
                table: "tbl_Person",
                column: "device_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Person_tbl_Device_device_Id1",
                table: "tbl_Person",
                column: "device_Id1",
                principalTable: "tbl_Device",
                principalColumn: "device_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
