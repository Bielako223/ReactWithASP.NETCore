﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    [DbContext(typeof(appDBContext))]
    partial class appDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("aspnetserver.Data.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = " This is post number: 1",
                            Title = "Post 1"
                        },
                        new
                        {
                            PostId = 2,
                            Content = " This is post number: 2",
                            Title = "Post 2"
                        },
                        new
                        {
                            PostId = 3,
                            Content = " This is post number: 3",
                            Title = "Post 3"
                        },
                        new
                        {
                            PostId = 4,
                            Content = " This is post number: 4",
                            Title = "Post 4"
                        },
                        new
                        {
                            PostId = 5,
                            Content = " This is post number: 5",
                            Title = "Post 5"
                        },
                        new
                        {
                            PostId = 6,
                            Content = " This is post number: 6",
                            Title = "Post 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
