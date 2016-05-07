using Microsoft.Data.Entity.Migrations;

namespace SoSmartTv.VideoService.Migrations
{
    public partial class DbInitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackdropPath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    PosterPath = table.Column<string>(nullable: true),
                    SourcePath = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("VideoItem");
        }
    }
}
