using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetaguardaESilva.Persistence.Migrations
{
    public partial class AjusteRelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatorioCadastro",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "RelatorioDetalhe",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "RelatorioEditar",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "RelatorioExcluir",
                table: "Permissao");

            migrationBuilder.RenameColumn(
                name: "VisualizarRelatorio",
                table: "Permissao",
                newName: "GerarRelatorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GerarRelatorio",
                table: "Permissao",
                newName: "VisualizarRelatorio");

            migrationBuilder.AddColumn<bool>(
                name: "RelatorioCadastro",
                table: "Permissao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RelatorioDetalhe",
                table: "Permissao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RelatorioEditar",
                table: "Permissao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RelatorioExcluir",
                table: "Permissao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
