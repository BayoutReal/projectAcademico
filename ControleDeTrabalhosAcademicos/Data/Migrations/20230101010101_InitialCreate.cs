using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeTrabalhosAcademicos.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabalhos",
                columns: table => new
                {
                    TrabalhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhos", x => x.TrabalhoId);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Curso = table.Column<string>(nullable: true),
                    TrabalhoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutorId);
                    table.ForeignKey(
                        name: "FK_Autores_Trabalhos_TrabalhoId",
                        column: x => x.TrabalhoId,
                        principalTable: "Trabalhos",
                        principalColumn: "TrabalhoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orientadores",
                columns: table => new
                {
                    OrientadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Curso = table.Column<string>(nullable: true),
                    TrabalhoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orientadores", x => x.OrientadorId);
                    table.ForeignKey(
                        name: "FK_Orientadores_Trabalhos_TrabalhoId",
                        column: x => x.TrabalhoId,
                        principalTable: "Trabalhos",
                        principalColumn: "TrabalhoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_TrabalhoId",
                table: "Autores",
                column: "TrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientadores_TrabalhoId",
                table: "Orientadores",
                column: "TrabalhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Orientadores");

            migrationBuilder.DropTable(
                name: "Trabalhos");
        }
    }
}
