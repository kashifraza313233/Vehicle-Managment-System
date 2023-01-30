using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VM.Data.Migrations
{
    /// <inheritdoc />
    public partial class services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service_Type",
                table: "VehicleInfomations");

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "VehicleInfomations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServicesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfomations_ServicesId",
                table: "VehicleInfomations",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfomations_Services_ServicesId",
                table: "VehicleInfomations",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfomations_Services_ServicesId",
                table: "VehicleInfomations");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfomations_ServicesId",
                table: "VehicleInfomations");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "VehicleInfomations");

            migrationBuilder.AddColumn<string>(
                name: "Service_Type",
                table: "VehicleInfomations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
