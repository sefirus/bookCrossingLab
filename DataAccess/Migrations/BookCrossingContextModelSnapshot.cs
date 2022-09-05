﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BookCrossingContext))]
    partial class BookCrossingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormattedAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

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
                            CreatedAt = new DateTime(2022, 9, 5, 14, 29, 37, 381, DateTimeKind.Local).AddTicks(9076),
                            Email = "admin@email.com",
                            FirstName = "Super",
                            IsActive = true,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 253, 141, 102, 47, 224, 26, 204, 5, 46, 118, 53, 155, 51, 112, 189, 194, 178, 85, 172, 130, 159, 37, 140, 134, 149, 82, 167, 67, 250, 46, 139, 86, 77, 2, 77, 64, 82, 91, 148, 70, 72, 136, 185, 55, 67, 233, 242, 89, 10, 231, 90, 207, 214, 249, 89, 62, 129, 109, 39, 139, 77, 42, 55, 103 },
                            PasswordSalt = new byte[] { 95, 64, 231, 106, 11, 33, 158, 86, 21, 104, 254, 68, 129, 60, 166, 99, 148, 41, 217, 245, 176, 78, 181, 209, 19, 220, 198, 110, 251, 253, 166, 81, 120, 171, 103, 19, 141, 1, 246, 232, 136, 178, 127, 209, 6, 163, 135, 170, 103, 204, 156, 5, 115, 4, 22, 107, 73, 26, 6, 97, 16, 129, 228, 29, 101, 186, 94, 82, 233, 247, 129, 21, 189, 159, 95, 6, 24, 9, 75, 81, 26, 6, 86, 29, 100, 6, 171, 5, 230, 250, 70, 216, 56, 114, 72, 200, 138, 253, 231, 136, 253, 212, 29, 189, 71, 75, 28, 224, 129, 129, 69, 180, 12, 19, 32, 148, 140, 86, 210, 16, 217, 30, 47, 183, 90, 87, 113, 138 },
                            RoleId = 1,
                            ShowCurrentBooks = true
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 9, 5, 14, 29, 37, 381, DateTimeKind.Local).AddTicks(9139),
                            Email = "powerUser@email.com",
                            FirstName = "Power",
                            IsActive = true,
                            LastName = "User",
                            PasswordHash = new byte[] { 203, 76, 93, 142, 78, 145, 237, 43, 117, 90, 87, 124, 170, 131, 241, 154, 62, 172, 52, 247, 166, 14, 129, 45, 143, 120, 66, 214, 46, 179, 231, 173, 0, 143, 186, 173, 165, 1, 123, 43, 60, 199, 144, 54, 172, 235, 16, 229, 38, 28, 5, 60, 138, 137, 54, 137, 175, 195, 245, 62, 201, 166, 218, 176 },
                            PasswordSalt = new byte[] { 63, 60, 169, 25, 185, 32, 242, 103, 85, 74, 219, 82, 148, 48, 128, 38, 103, 160, 76, 142, 116, 193, 91, 140, 111, 176, 154, 79, 62, 25, 10, 135, 238, 103, 254, 174, 73, 37, 163, 75, 79, 130, 118, 235, 201, 43, 168, 100, 153, 182, 145, 245, 184, 81, 1, 78, 218, 73, 109, 171, 135, 252, 124, 244, 255, 204, 169, 90, 59, 99, 178, 6, 220, 158, 193, 53, 44, 13, 9, 217, 189, 5, 140, 197, 13, 226, 33, 67, 242, 72, 61, 220, 206, 122, 54, 190, 243, 63, 119, 148, 28, 124, 213, 197, 21, 47, 82, 208, 105, 113, 199, 244, 214, 238, 131, 133, 154, 145, 49, 235, 75, 150, 116, 116, 40, 132, 14, 167 },
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
