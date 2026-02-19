using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Migrations
{
    /// <inheritdoc />
    public partial class CarModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Model_ModelID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.CreateTable(
                name: "ModelsCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsCars", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ModelsCars_ModelID",
                table: "Cars",
                column: "ModelID",
                principalTable: "ModelsCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ModelsCars_ModelID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "ModelsCars");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Model_ModelID",
                table: "Cars",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
