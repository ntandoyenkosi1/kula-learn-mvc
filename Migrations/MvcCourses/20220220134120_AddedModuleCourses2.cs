using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KulaMVC.Migrations.MvcCourses
{
    public partial class AddedModuleCourses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    collectionID = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    shortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    createdAt = table.Column<int>(type: "INTEGER", nullable: false),
                    uploader = table.Column<string>(type: "TEXT", nullable: false),
                    published = table.Column<bool>(type: "INTEGER", nullable: false),
                    visibility = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    collectionID = table.Column<string>(type: "TEXT", nullable: false),
                    language = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    shortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    longDescription = table.Column<string>(type: "TEXT", nullable: false),
                    video = table.Column<string>(type: "TEXT", nullable: true),
                    uploader = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Course");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}
