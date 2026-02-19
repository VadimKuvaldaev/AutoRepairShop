using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Migrations
{
    /// <inheritdoc />
    public partial class CarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientId",
                table: "Cars",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelID",
                table: "Cars",
                column: "ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Model_ModelID",
                table: "Cars",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Model_ModelID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ClientId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
