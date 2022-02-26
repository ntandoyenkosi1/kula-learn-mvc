using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KulaLearnMVC.Data.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    collectionID = table.Column<string>(type: "TEXT", nullable: true),
                    language = table.Column<string>(type: "TEXT", nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    shortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    longDescription = table.Column<string>(type: "TEXT", nullable: true),
                    video = table.Column<string>(type: "TEXT", nullable: true),
                    uploader = table.Column<string>(type: "TEXT", nullable: true),
                    iat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}
