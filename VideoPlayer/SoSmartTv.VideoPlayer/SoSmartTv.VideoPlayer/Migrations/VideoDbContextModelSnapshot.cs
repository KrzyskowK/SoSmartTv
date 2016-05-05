using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    partial class VideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
