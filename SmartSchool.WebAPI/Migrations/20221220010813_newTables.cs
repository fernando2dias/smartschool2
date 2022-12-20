using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class newTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3899), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3908), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3912), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3916), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3920), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3925), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3929), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" },
                    { 4, "Engenharia da Computação" },
                    { 5, "Analises de Sistema" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3680), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3692), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3693), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3743), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3744), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 },
                    { 11, 0, 4, "Programação", null, 5 },
                    { 12, 0, 5, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3975), null },
                    { 1, 4, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3979), null },
                    { 1, 5, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3980), null },
                    { 2, 1, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3981), null },
                    { 2, 2, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3982), null },
                    { 2, 5, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3984), null },
                    { 3, 1, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3984), null },
                    { 3, 2, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3985), null },
                    { 3, 3, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3986), null },
                    { 4, 1, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3988), null },
                    { 4, 4, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3989), null },
                    { 4, 5, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3989), null },
                    { 5, 4, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3990), null },
                    { 5, 5, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3991), null },
                    { 6, 1, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3992), null },
                    { 6, 2, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3993), null },
                    { 6, 3, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3993), null },
                    { 6, 4, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3995), null },
                    { 7, 1, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3996), null },
                    { 7, 2, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3997), null },
                    { 7, 3, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3997), null },
                    { 7, 4, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3998), null },
                    { 7, 5, null, new DateTime(2022, 12, 19, 22, 8, 13, 734, DateTimeKind.Local).AddTicks(3999), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCursos_CursoId",
                table: "AlunoCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCursos");

            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
