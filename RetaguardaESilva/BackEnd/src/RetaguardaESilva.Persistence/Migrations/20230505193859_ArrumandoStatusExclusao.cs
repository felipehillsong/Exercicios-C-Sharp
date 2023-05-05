using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetaguardaESilva.Persistence.Migrations
{
    public partial class ArrumandoStatusExclusao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusExclusao",
                table: "Transportador",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusExclusao",
                table: "Funcionario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusExclusao",
                table: "Fornecedor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusExclusao",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusExclusao",
                table: "Transportador");

            migrationBuilder.DropColumn(
                name: "StatusExclusao",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "StatusExclusao",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "StatusExclusao",
                table: "Cliente");
        }
    }
}
