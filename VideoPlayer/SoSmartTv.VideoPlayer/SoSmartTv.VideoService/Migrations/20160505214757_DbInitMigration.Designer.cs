using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace SoSmartTv.VideoService.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    [Migration("20160505214757_DbInitMigration")]
    partial class DbInitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("SoSmartTv.VideoPlayer.ViewModels.VideoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackdropPath");

                    b.Property<string>("Description");

                    b.Property<string>("Genre");

                    b.Property<string>("PosterPath");

                    b.Property<string>("SourcePath");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });
        }
    }
}
