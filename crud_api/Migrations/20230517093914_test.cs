using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace crud_api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Device",
                columns: table => new
                {
                    device_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Device", x => x.device_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Person",
                columns: table => new
                {
                    person_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_Name = table.Column<string>(type: "text", nullable: false),
                    person_Email = table.Column<string>(type: "text", nullable: false),
                    person_Address = table.Column<string>(type: "text", nullable: false),
                    person_Phone = table.Column<long>(type: "bigint", nullable: false),
                    device_Id = table.Column<int>(type: "integer", nullable: false),
                    device_Id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Person", x => x.person_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Person_tbl_Device_device_Id1",
                        column: x => x.device_Id1,
                        principalTable: "tbl_Device",
                        principalColumn: "device_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Person_device_Id1",
                table: "tbl_Person",
                column: "device_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Person");

            migrationBuilder.DropTable(
                name: "tbl_Device");
        }
    }
}
