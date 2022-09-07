using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixedCommentForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookCopyId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 7, 12, 30, 1, 426, DateTimeKind.Local).AddTicks(93), new byte[] { 215, 253, 87, 78, 105, 249, 149, 78, 220, 197, 15, 189, 250, 201, 144, 99, 130, 48, 5, 136, 205, 54, 29, 102, 187, 50, 226, 102, 192, 101, 157, 147, 215, 57, 218, 253, 85, 151, 158, 66, 1, 205, 4, 199, 214, 230, 78, 213, 137, 19, 60, 187, 129, 208, 135, 82, 212, 121, 212, 123, 239, 69, 161, 200 }, new byte[] { 42, 198, 28, 10, 31, 182, 193, 58, 239, 95, 154, 107, 190, 167, 216, 228, 137, 21, 201, 8, 208, 220, 242, 33, 159, 126, 169, 74, 163, 76, 240, 109, 23, 31, 231, 209, 176, 63, 52, 72, 30, 54, 66, 146, 3, 251, 157, 84, 168, 74, 24, 158, 11, 206, 147, 130, 204, 195, 1, 150, 159, 22, 144, 164, 127, 115, 168, 56, 166, 204, 51, 136, 64, 140, 29, 171, 201, 26, 197, 120, 161, 54, 5, 92, 3, 155, 244, 144, 2, 164, 100, 207, 116, 51, 104, 214, 32, 66, 55, 163, 89, 19, 227, 158, 11, 117, 9, 119, 110, 10, 116, 169, 162, 172, 188, 222, 111, 116, 103, 137, 95, 100, 39, 10, 133, 254, 174, 178 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 7, 12, 30, 1, 426, DateTimeKind.Local).AddTicks(156), new byte[] { 101, 8, 171, 14, 15, 246, 196, 243, 135, 91, 224, 193, 155, 34, 194, 115, 192, 229, 78, 252, 137, 150, 101, 38, 3, 111, 139, 241, 247, 132, 12, 143, 18, 65, 179, 153, 90, 142, 214, 100, 146, 50, 25, 6, 108, 186, 152, 114, 227, 134, 76, 118, 36, 38, 51, 58, 176, 238, 15, 25, 254, 14, 225, 172 }, new byte[] { 57, 10, 28, 7, 17, 69, 57, 146, 4, 133, 59, 161, 47, 254, 96, 102, 184, 233, 86, 184, 241, 209, 58, 224, 239, 194, 47, 45, 233, 168, 91, 33, 136, 212, 2, 4, 169, 211, 19, 227, 96, 112, 35, 140, 167, 9, 175, 133, 139, 99, 238, 152, 147, 151, 20, 44, 143, 129, 20, 204, 64, 62, 52, 102, 175, 157, 185, 20, 193, 192, 175, 181, 92, 189, 81, 49, 12, 48, 46, 176, 139, 74, 50, 193, 67, 138, 124, 139, 140, 75, 234, 178, 217, 167, 18, 237, 85, 11, 205, 148, 133, 53, 6, 22, 163, 165, 65, 69, 61, 180, 135, 177, 232, 213, 53, 163, 238, 125, 140, 66, 9, 250, 105, 134, 112, 64, 105, 180 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookCopyId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 6, 11, 49, 15, 838, DateTimeKind.Local).AddTicks(6829), new byte[] { 43, 188, 123, 191, 110, 207, 213, 146, 147, 51, 212, 178, 65, 10, 144, 123, 195, 251, 46, 237, 172, 36, 241, 233, 197, 95, 248, 99, 174, 174, 216, 14, 133, 45, 22, 230, 113, 98, 40, 54, 234, 76, 64, 33, 17, 150, 28, 78, 123, 72, 244, 205, 162, 13, 208, 193, 241, 201, 31, 216, 110, 53, 233, 177 }, new byte[] { 197, 24, 110, 17, 43, 235, 30, 243, 97, 230, 114, 172, 171, 239, 248, 193, 231, 67, 233, 47, 127, 95, 196, 68, 234, 255, 31, 134, 19, 44, 218, 151, 106, 43, 56, 62, 107, 143, 96, 191, 164, 174, 10, 43, 97, 107, 38, 131, 133, 236, 238, 109, 174, 107, 251, 2, 17, 170, 192, 23, 68, 106, 191, 224, 228, 248, 245, 108, 246, 229, 112, 125, 80, 182, 48, 58, 124, 57, 60, 153, 174, 171, 172, 230, 84, 36, 63, 228, 201, 109, 178, 240, 199, 53, 141, 212, 167, 16, 109, 172, 151, 63, 229, 129, 110, 150, 174, 7, 197, 154, 85, 185, 150, 156, 168, 24, 153, 223, 208, 43, 149, 88, 73, 154, 8, 147, 13, 173 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 6, 11, 49, 15, 838, DateTimeKind.Local).AddTicks(6903), new byte[] { 174, 182, 92, 155, 87, 41, 137, 226, 105, 145, 44, 167, 158, 180, 2, 202, 196, 215, 90, 95, 106, 248, 127, 190, 175, 100, 254, 149, 8, 13, 251, 48, 212, 248, 182, 44, 122, 197, 232, 197, 175, 163, 215, 27, 75, 106, 168, 140, 148, 179, 41, 25, 161, 135, 111, 71, 21, 15, 104, 94, 200, 69, 166, 231 }, new byte[] { 96, 112, 71, 79, 38, 93, 19, 147, 95, 63, 221, 133, 10, 109, 157, 238, 108, 90, 252, 245, 143, 47, 32, 112, 201, 169, 106, 27, 150, 110, 8, 91, 59, 48, 161, 130, 215, 244, 254, 247, 144, 31, 107, 174, 34, 206, 107, 174, 90, 2, 71, 82, 127, 19, 167, 53, 101, 61, 3, 8, 69, 127, 225, 215, 131, 48, 115, 233, 184, 234, 6, 176, 195, 254, 72, 219, 156, 106, 117, 21, 221, 102, 96, 91, 180, 70, 27, 7, 159, 96, 127, 226, 13, 100, 212, 218, 4, 91, 77, 108, 106, 28, 66, 213, 16, 92, 57, 239, 15, 46, 101, 124, 0, 18, 123, 160, 231, 83, 40, 162, 9, 62, 182, 93, 19, 116, 119, 113 } });
        }
    }
}
