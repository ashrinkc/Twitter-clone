﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using twitter_api.Data;

#nullable disable

namespace twitter_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("twitter_api.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("like")
                        .HasColumnType("int");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.Property<int>("quotes")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("postId");

                    b.HasIndex("userId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("twitter_api.Models.Follower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("twitter_api.Models.Following", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("twitter_api.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Search")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("twitter_api.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("postOrcommentId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("userId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("twitter_api.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("comments")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<int>("quotes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("twitter_api.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsQuote")
                        .HasColumnType("bit");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("postOrcommentId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("userId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("twitter_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("joinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("twitter_api.Models.Comment", b =>
                {
                    b.HasOne("twitter_api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("postId");

                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.Follower", b =>
                {
                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.Following", b =>
                {
                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.History", b =>
                {
                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.Like", b =>
                {
                    b.HasOne("twitter_api.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Comment");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.Post", b =>
                {
                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("twitter_api.Models.Quote", b =>
                {
                    b.HasOne("twitter_api.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Comment");

                    b.Navigation("Post");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
