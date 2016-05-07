using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace SoSmartTv.VideoService.Migrations
{
	[DbContext(typeof(VideoDbContext))]
    [Migration("20160506215225_AddingVideoDetailsItems")]
    partial class AddingVideoDetailsItems
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

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Genre");

                    b.Property<string>("PosterPath");

                    b.Property<string>("SourcePath");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "VideoItem");
                });

            modelBuilder.Entity("SoSmartTv.VideoPlayer.ViewModels.VideoDetailsItem", b =>
                {
                    b.HasBaseType("SoSmartTv.VideoPlayer.ViewModels.VideoItem");

                    b.Property<string>("OriginalLanguage");

                    b.Property<string>("OriginalTitle");

                    b.Property<string>("ReleaseDate");

                    b.Property<int>("Revenue");

                    b.Property<int>("Runtime");

                    b.Property<double>("VoteAverage");

                    b.Property<int>("VoteCount");

                    b.HasAnnotation("Relational:DiscriminatorValue", "VideoDetailsItem");
                });
        }
    }
}
