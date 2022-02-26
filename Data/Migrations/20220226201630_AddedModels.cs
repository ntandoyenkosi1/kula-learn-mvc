using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KulaLearnMVC.Data.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    collectionID = table.Column<string>(type: "TEXT", nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    shortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    createdAt = table.Column<int>(type: "INTEGER", nullable: false),
                    uploader = table.Column<string>(type: "TEXT", nullable: true),
                    published = table.Column<int>(type: "INTEGER", nullable: false),
                    visibility = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
