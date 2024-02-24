using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestaoCursos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlunoCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ATIVO",
                table: "CURSO",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ATIVO",
                table: "ALUNO",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATIVO",
                table: "CURSO");

            migrationBuilder.DropColumn(
                name: "ATIVO",
                table: "ALUNO");
        }
    }
}
