﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BookCrossingContext))]
    [Migration("20230201182948_AddRepoDecorator")]
    partial class AddRepoDecorator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("GoogleApiId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BookCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentShelfId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentUserId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CurrentShelfId");

                    b.HasIndex("CurrentUserId");

                    b.ToTable("BookCopies", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BookWriter", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("BookWriters", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = ""
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Magazines",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Fiction",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "Non-Fiction",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            Name = "Handbooks",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "",
                            Name = "Uncategorized",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "",
                            Name = "Detective",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 8,
                            Description = "",
                            Name = "Prose",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 9,
                            Description = "",
                            Name = "Sci-Fi",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 10,
                            Description = "",
                            Name = "Fantasy",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 11,
                            Description = "",
                            Name = "Horrors",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 12,
                            Description = "",
                            Name = "Poetry",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 13,
                            Description = "",
                            Name = "Drama",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 14,
                            Description = "",
                            Name = "Historical Novels",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 15,
                            Description = "",
                            Name = "Esotericism",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 16,
                            Description = "",
                            Name = "Business",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 17,
                            Description = "",
                            Name = "Social",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 18,
                            Description = "",
                            Name = "Biographies",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 19,
                            Description = "",
                            Name = "Economics",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 20,
                            Description = "",
                            Name = "Technical literature",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 21,
                            Description = "",
                            Name = "Science",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 22,
                            Description = "",
                            Name = "Philosophy",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 23,
                            Description = "",
                            Name = "Motivational literature",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 24,
                            Description = "",
                            Name = "Religion",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 25,
                            Description = "",
                            Name = "Self Development",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 26,
                            Description = "",
                            Name = "Hobbies",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            Id = 27,
                            Description = "",
                            Name = "Reference books",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 28,
                            Description = "",
                            Name = "Encyclopedias",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 29,
                            Description = "",
                            Name = "Reference books",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 30,
                            Description = "",
                            Name = "Educational Literature",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 31,
                            Description = "",
                            Name = "Dictionaries",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 32,
                            Description = "",
                            Name = "Maps",
                            ParentCategoryId = 5
                        },
                        new
                        {
                            Id = 33,
                            Description = "",
                            Name = "Atlases",
                            ParentCategoryId = 5
                        });
                });

            modelBuilder.Entity("Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Edited")
                        .HasColumnType("bit");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("BookId");

                    b.HasIndex("ShelfId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("FullPath")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int?>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("BookId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("ShelfId");

                    b.HasIndex("WriterId");

                    b.ToTable("Pictures", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Publishers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SUPER ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "POWER USER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "USER"
                        });
                });

            modelBuilder.Entity("Core.Entities.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormattedAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Shelves", (string)null);
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("ProfilePictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("ShowCurrentBooks")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProfilePictureId")
                        .IsUnique()
                        .HasFilter("[ProfilePictureId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2023, 2, 1, 20, 29, 48, 337, DateTimeKind.Local).AddTicks(6453),
                            Email = "admin@email.com",
                            FirstName = "Super",
                            IsActive = true,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 57, 63, 162, 248, 86, 89, 138, 252, 229, 94, 110, 131, 235, 31, 221, 0, 138, 122, 31, 155, 60, 232, 118, 13, 154, 41, 91, 135, 107, 137, 199, 16, 96, 52, 70, 118, 34, 92, 188, 6, 84, 27, 207, 52, 238, 155, 60, 191, 67, 168, 54, 247, 123, 90, 119, 168, 108, 39, 51, 252, 217, 63, 253, 46 },
                            PasswordSalt = new byte[] { 22, 40, 108, 76, 252, 240, 0, 12, 148, 46, 148, 181, 134, 33, 203, 220, 73, 217, 127, 249, 247, 81, 29, 83, 195, 77, 9, 83, 95, 17, 26, 17, 65, 215, 222, 98, 104, 29, 99, 82, 169, 68, 80, 201, 99, 234, 154, 199, 60, 48, 61, 99, 200, 61, 65, 48, 53, 111, 243, 98, 196, 10, 53, 46, 226, 158, 234, 239, 160, 1, 44, 119, 248, 197, 129, 141, 245, 186, 30, 171, 46, 253, 7, 32, 1, 223, 31, 165, 106, 203, 69, 197, 97, 62, 95, 128, 170, 156, 4, 102, 40, 163, 29, 252, 165, 95, 165, 202, 109, 49, 169, 82, 215, 52, 69, 179, 9, 200, 109, 17, 125, 18, 146, 61, 82, 158, 229, 75 },
                            RoleId = 1,
                            ShowCurrentBooks = true
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2023, 2, 1, 20, 29, 48, 337, DateTimeKind.Local).AddTicks(6562),
                            Email = "powerUser@email.com",
                            FirstName = "Power",
                            IsActive = true,
                            LastName = "User",
                            PasswordHash = new byte[] { 196, 235, 218, 178, 232, 94, 90, 197, 105, 66, 179, 101, 186, 74, 81, 155, 248, 64, 233, 214, 69, 129, 38, 234, 253, 46, 187, 179, 149, 117, 96, 156, 47, 126, 168, 151, 195, 180, 66, 181, 184, 236, 229, 229, 132, 85, 86, 101, 187, 208, 204, 27, 63, 85, 212, 8, 231, 179, 228, 173, 212, 54, 239, 161 },
                            PasswordSalt = new byte[] { 38, 117, 11, 132, 133, 91, 119, 22, 248, 48, 60, 188, 229, 102, 208, 244, 131, 109, 164, 125, 245, 68, 40, 117, 81, 182, 7, 23, 139, 201, 16, 39, 142, 138, 232, 110, 61, 181, 200, 208, 244, 147, 140, 21, 122, 65, 187, 77, 77, 59, 218, 40, 149, 14, 148, 5, 84, 67, 32, 83, 156, 147, 63, 18, 119, 14, 202, 109, 212, 152, 231, 12, 53, 189, 128, 138, 94, 6, 171, 157, 230, 167, 81, 213, 9, 215, 124, 34, 93, 145, 14, 82, 21, 184, 232, 38, 125, 219, 238, 43, 224, 22, 237, 222, 169, 44, 234, 173, 128, 180, 215, 67, 132, 208, 241, 230, 140, 157, 224, 3, 62, 79, 99, 126, 31, 233, 217, 109 },
                            RoleId = 2,
                            ShowCurrentBooks = true
                        });
                });

            modelBuilder.Entity("Core.Entities.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Writers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Book", b =>
                {
                    b.HasOne("Core.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Core.Entities.BookCategory", b =>
                {
                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Category", "Category")
                        .WithMany("BookCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Entities.BookCopy", b =>
                {
                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Shelf", "CurrentShelf")
                        .WithMany("BookCopies")
                        .HasForeignKey("CurrentShelfId");

                    b.HasOne("Core.Entities.User", "CurrentUser")
                        .WithMany("CurrentBooks")
                        .HasForeignKey("CurrentUserId");

                    b.Navigation("Book");

                    b.Navigation("CurrentShelf");

                    b.Navigation("CurrentUser");
                });

            modelBuilder.Entity("Core.Entities.BookWriter", b =>
                {
                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("BookWriters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Writer", "Writer")
                        .WithMany("BookWriters")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.HasOne("Core.Entities.Category", "PrentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("PrentCategory");
                });

            modelBuilder.Entity("Core.Entities.Comment", b =>
                {
                    b.HasOne("Core.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.BookCopy", "BookCopy")
                        .WithMany("Comments")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Shelf", "Shelf")
                        .WithMany("Comments")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Author");

                    b.Navigation("Book");

                    b.Navigation("BookCopy");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Core.Entities.Picture", b =>
                {
                    b.HasOne("Core.Entities.BookCopy", "BookCopy")
                        .WithMany("Pictures")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("Pictures")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Publisher", "Publisher")
                        .WithMany("Pictures")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Shelf", "Shelf")
                        .WithMany("Pictures")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Writer", "Writer")
                        .WithMany("Pictures")
                        .HasForeignKey("WriterId");

                    b.Navigation("Book");

                    b.Navigation("BookCopy");

                    b.Navigation("Publisher");

                    b.Navigation("Shelf");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Picture", "ProfilePicture")
                        .WithOne("User")
                        .HasForeignKey("Core.Entities.User", "ProfilePictureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfilePicture");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Entities.Book", b =>
                {
                    b.Navigation("BookCategories");

                    b.Navigation("BookCopies");

                    b.Navigation("BookWriters");

                    b.Navigation("Comments");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Core.Entities.BookCopy", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Navigation("BookCategories");

                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("Core.Entities.Picture", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Publisher", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Core.Entities.Shelf", b =>
                {
                    b.Navigation("BookCopies");

                    b.Navigation("Comments");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CurrentBooks");
                });

            modelBuilder.Entity("Core.Entities.Writer", b =>
                {
                    b.Navigation("BookWriters");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
