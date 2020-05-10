using Microsoft.EntityFrameworkCore.Migrations;

namespace Campeonato.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pontuacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Posicao = table.Column<int>(nullable: false),
                    CampeonatoId = table.Column<int>(nullable: false),
                    ClubeId = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Jogos = table.Column<int>(nullable: false),
                    Vitorias = table.Column<int>(nullable: false),
                    Empates = table.Column<int>(nullable: false),
                    Derrotas = table.Column<int>(nullable: false),
                    GolsPro = table.Column<int>(nullable: false),
                    GolsContra = table.Column<int>(nullable: false),
                    GolsSaldo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontuacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontuacoes_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pontuacoes_Clubes_ClubeId",
                        column: x => x.ClubeId,
                        principalTable: "Clubes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pontuacoes_CampeonatoId",
                table: "Pontuacoes",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pontuacoes_ClubeId",
                table: "Pontuacoes",
                column: "ClubeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pontuacoes");

            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "Clubes");
        }
    }
}
