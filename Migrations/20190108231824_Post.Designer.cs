﻿// <auto-generated />
using System;
using Blogging.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blogging.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20190108231824_Post")]
    partial class Post
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Blogging.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("AuthorId");

                    b.ToTable("authors");

                    b.HasData(
                        new { AuthorId = 1, FirstName = "William", LastName = "Shakespeare" },
                        new { AuthorId = 2, FirstName = "Bibi", LastName = "Treffers" }
                    );
                });

            modelBuilder.Entity("Blogging.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("PostId");

                    b.HasKey("CommentId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Blogging.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PostId");

                    b.HasIndex("AuthorId");

                    b.ToTable("posts");

                    b.HasData(
                        new { PostId = 1, AuthorId = 2, Content = "Shakespeare", Date = new DateTime(2019, 1, 9, 0, 18, 23, 419, DateTimeKind.Local), Title = "William" }
                    );
                });

            modelBuilder.Entity("Blogging.Models.Comment", b =>
                {
                    b.HasOne("Blogging.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blogging.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Blogging.Models.Post", b =>
                {
                    b.HasOne("Blogging.Models.Author", "AuthorName")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}