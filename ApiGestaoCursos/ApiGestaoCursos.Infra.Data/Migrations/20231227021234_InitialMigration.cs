using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestaoCursos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CURSO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRICAO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAINICIO = table.Column<DateTime>(name: "DATA_INICIO", type: "datetime(6)", nullable: false),
                    DATAFIM = table.Column<DateTime>(name: "DATA_FIM", type: "datetime(6)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(name: "DATA_CRIACAO", type: "datetime(6)", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(name: "DATA_ATUALIZACAO", type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSO", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATANASCIMENTO = table.Column<DateTime>(name: "DATA_NASCIMENTO", type: "datetime(6)", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CursoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DATACRIACAO = table.Column<DateTime>(name: "DATA_CRIACAO", type: "datetime(6)", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(name: "DATA_ATUALIZACAO", type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALUNO_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "CURSO",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_CursoId",
                table: "ALUNO",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_EMAIL",
                table: "ALUNO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "CURSO");
        }
    }
}
