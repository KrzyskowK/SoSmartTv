using Microsoft.Data.Entity.Migrations;

namespace SoSmartTv.VideoService.Migrations
{
    public partial class AddingVideoDetailsItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "VideoItem",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "OriginalTitle",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Revenue",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Runtime",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<double>(
                name: "VoteAverage",
                table: "VideoItem",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "VideoItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Discriminator", table: "VideoItem");
            migrationBuilder.DropColumn(name: "OriginalLanguage", table: "VideoItem");
            migrationBuilder.DropColumn(name: "OriginalTitle", table: "VideoItem");
            migrationBuilder.DropColumn(name: "ReleaseDate", table: "VideoItem");
            migrationBuilder.DropColumn(name: "Revenue", table: "VideoItem");
            migrationBuilder.DropColumn(name: "Runtime", table: "VideoItem");
            migrationBuilder.DropColumn(name: "VoteAverage", table: "VideoItem");
            migrationBuilder.DropColumn(name: "VoteCount", table: "VideoItem");
        }
    }
}
