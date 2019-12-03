using Microsoft.EntityFrameworkCore.Migrations;

namespace TP03GestionTournois.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournois",
                columns: table => new
                {
                    IdTournoi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Prix = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Jeu = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournois", x => x.IdTournoi);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournois");
        }
    }
}
