using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ClientCar_ClientId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCar_ClientCarId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ClientId1",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCar",
                table: "ClientCar");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "ClientCar",
                newName: "ClientCars");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCars",
                table: "ClientCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCars_ClientCarId",
                table: "Clients",
                column: "ClientCarId",
                principalTable: "ClientCars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCars_ClientCarId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCars",
                table: "ClientCars");

            migrationBuilder.RenameTable(
                name: "ClientCars",
                newName: "ClientCar");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCar",
                table: "ClientCar",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientId1",
                table: "Cars",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ClientCar_ClientId1",
                table: "Cars",
                column: "ClientId1",
                principalTable: "ClientCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_ClientId",
                table: "Cars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCar_ClientCarId",
                table: "Clients",
                column: "ClientCarId",
                principalTable: "ClientCar",
                principalColumn: "Id");
        }
    }
}
