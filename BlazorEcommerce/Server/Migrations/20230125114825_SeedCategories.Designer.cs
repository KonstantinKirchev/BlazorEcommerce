﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(BlazorEcommerceDbContext))]
    [Migration("20230125114825_SeedCategories")]
    partial class SeedCategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The Man in the High Castle (1962), by Philip K. Dick, is an alternative history novel wherein the Axis Powers won World War II. The story occurs in 1962, fifteen years after the end of the war in 1947, and depicts the political intrigues between Imperial Japan and Nazi Germany as they rule the partitioned United States. The titular character is the author of a novel-within-the-novel entitled The Grasshopper Lies Heavy, itself also an alternative history of the war.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/Man_in_the_High_Castle_%281st_Edition%29.png",
                            Price = 9.99m,
                            Title = "The Man in the High Castle"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "The Lost Daughter is a 2021 psychological drama film adapted for the screen and directed by Maggie Gyllenhaal (in her feature directorial debut) based on the 2006 novel of the same name by Elena Ferrante. The film stars Olivia Colman, Dakota Johnson, Jessie Buckley, Paul Mescal, Dagmara Domińczyk, Jack Farthing, Oliver Jackson-Cohen, with Peter Sarsgaard, and Ed Harris. Colman also serves as an executive producer.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/The_Lost_Daughter_%28film%29.jpg",
                            Price = 1.59m,
                            Title = "The Lost Daughter"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "The Terminal List is an American action thriller television series based on Jack Carr's 2018 novel of the same name.[1] The series tells the story of a Navy SEAL who seeks to avenge the murder of his family. It stars Chris Pratt (who also serves as an executive producer), Constance Wu, Taylor Kitsch, Riley Keough, Arlo Mertz, and Jeanne Tripplehorn.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ed/The_Terminal_List.jpeg",
                            Price = 4.99m,
                            Title = "The Terminal List"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Models.Product", b =>
                {
                    b.HasOne("BlazorEcommerce.Shared.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}