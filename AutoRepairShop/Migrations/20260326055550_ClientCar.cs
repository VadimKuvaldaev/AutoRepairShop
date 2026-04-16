using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Migrations
{
    /// <inheritdoc />
    public partial class ClientCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ModelsCars_BrandId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelsCars",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "ModelsCars",
                newName: "BrandCars");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Cars",
                newName: "ClientId1");

            migrationBuilder.AddColumn<int>(
                name: "ClientCarId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientCarId",
                table: "Clients",
                column: "ClientCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientId1",
                table: "Cars",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BrandCars_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ClientCar_ClientId1",
                table: "Cars",
                column: "ClientId1",
                principalTable: "ClientCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCar_ClientCarId",
                table: "Clients",
                column: "ClientCarId",
                principalTable: "ClientCar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BrandCars_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ClientCar_ClientId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCar_ClientCarId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientCar");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientCarId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ClientId1",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars");

            migrationBuilder.DropColumn(
                name: "ClientCarId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "BrandCars",
                newName: "ModelsCars");

            migrationBuilder.RenameColumn(
                name: "ClientId1",
                table: "Cars",
                newName: "ModelID");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelsCars",
                table: "ModelsCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ModelsCars_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "ModelsCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
