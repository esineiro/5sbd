using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Periodo = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Creditos = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: true),
                    NotaAV1 = table.Column<decimal>(type: "decimal(4,2)", maxLength: 5, precision: 4, scale: 2, nullable: true),
                    NotaAV2 = table.Column<decimal>(type: "decimal(4,2)", maxLength: 5, precision: 4, scale: 2, nullable: true),
                    NotaAVS = table.Column<decimal>(type: "decimal(4,2)", maxLength: 5, precision: 4, scale: 2, nullable: true),
                    NotaAVF = table.Column<decimal>(type: "decimal(4,2)", maxLength: 5, precision: 4, scale: 2, nullable: true),
                    Faltas = table.Column<int>(type: "int", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdDisciplina = table.Column<int>(type: "int", nullable: false),
                    IdProfessor = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: true),
                    Turno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
