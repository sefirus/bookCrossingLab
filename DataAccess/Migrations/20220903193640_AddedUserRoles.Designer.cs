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
    [Migration("20220903193640_AddedUserRoles")]
    partial class AddedUserRoles
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

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

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

                    b.Property<int>("CurrentShelfId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentUserId")
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

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("Edited")
                        .HasColumnType("bit");

                    b.Property<int>("ShelfId")
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

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                            CreatedAt = new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4615),
                            Email = "admin@email.com",
                            FirstName = "Super",
                            IsActive = true,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 220, 207, 220, 235, 226, 197, 247, 125, 191, 200, 244, 104, 246, 245, 93, 49, 192, 144, 83, 121, 145, 224, 80, 211, 105, 166, 52, 28, 238, 1, 148, 167, 223, 122, 228, 149, 20, 27, 167, 58, 2, 210, 208, 146, 31, 65, 252, 165, 203, 240, 13, 220, 244, 45, 204, 10, 34, 236, 40, 188, 79, 131, 97, 46 },
                            PasswordSalt = new byte[] { 246, 233, 52, 119, 248, 141, 85, 55, 32, 214, 136, 240, 40, 29, 58, 120, 200, 10, 81, 211, 226, 174, 38, 4, 153, 198, 34, 44, 1, 57, 59, 194, 45, 91, 140, 0, 107, 17, 53, 199, 27, 214, 193, 10, 57, 42, 99, 215, 54, 184, 225, 117, 218, 145, 96, 8, 153, 123, 41, 28, 194, 28, 38, 12, 19, 158, 253, 40, 55, 232, 179, 207, 145, 240, 119, 69, 221, 62, 115, 239, 255, 24, 208, 138, 28, 99, 144, 121, 134, 109, 70, 158, 9, 116, 173, 178, 194, 131, 206, 87, 165, 230, 28, 47, 47, 95, 27, 95, 8, 134, 174, 108, 20, 61, 106, 248, 178, 30, 32, 10, 154, 7, 8, 52, 59, 255, 8, 204 },
                            RoleId = 1,
                            ShowCurrentBooks = true
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4682),
                            Email = "powerUser@email.com",
                            FirstName = "Power",
                            IsActive = true,
                            LastName = "User",
                            PasswordHash = new byte[] { 238, 180, 162, 178, 1, 247, 89, 118, 103, 125, 161, 58, 131, 132, 174, 203, 108, 97, 82, 252, 113, 229, 3, 159, 221, 216, 53, 29, 156, 178, 82, 188, 75, 15, 192, 111, 22, 142, 163, 118, 206, 196, 119, 62, 167, 109, 27, 131, 157, 168, 228, 139, 118, 202, 10, 226, 203, 222, 242, 17, 251, 46, 214, 41 },
                            PasswordSalt = new byte[] { 7, 233, 48, 16, 15, 252, 138, 161, 239, 182, 216, 185, 105, 8, 66, 222, 44, 162, 177, 10, 246, 139, 144, 47, 10, 108, 51, 216, 15, 123, 248, 18, 214, 195, 249, 41, 235, 245, 7, 31, 75, 14, 19, 227, 69, 62, 219, 148, 144, 82, 225, 241, 172, 231, 2, 232, 46, 1, 208, 1, 105, 145, 38, 192, 64, 74, 107, 170, 169, 177, 226, 230, 118, 246, 169, 241, 33, 199, 217, 65, 128, 7, 185, 193, 235, 250, 233, 227, 73, 45, 150, 90, 57, 7, 121, 14, 200, 82, 231, 130, 29, 214, 207, 88, 30, 189, 216, 85, 214, 41, 151, 169, 186, 24, 50, 58, 74, 160, 219, 32, 251, 215, 33, 143, 46, 137, 61, 196 },
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
                        .WithMany("Books")
                        .HasForeignKey("CurrentShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "CurrentUser")
                        .WithMany("CurrentBooks")
                        .HasForeignKey("CurrentUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Shelf", "Shelf")
                        .WithMany("Comments")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");

                    b.Navigation("BookCopy");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Core.Entities.Picture", b =>
                {
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
                    b.Navigation("Books");

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