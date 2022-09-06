using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixedBookCopyForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Shelves_CurrentShelfId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Users_CurrentUserId",
                table: "BookCopies");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentUserId",
                table: "BookCopies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentShelfId",
                table: "BookCopies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Shelves_CurrentShelfId",
                table: "BookCopies",
                column: "CurrentShelfId",
                principalTable: "Shelves",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Users_CurrentUserId",
                table: "BookCopies",
                column: "CurrentUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Shelves_CurrentShelfId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Users_CurrentUserId",
                table: "BookCopies");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentUserId",
                table: "BookCopies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentShelfId",
                table: "BookCopies",
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
                values: new object[] { new DateTime(2022, 9, 5, 16, 43, 53, 282, DateTimeKind.Local).AddTicks(1682), new byte[] { 213, 221, 109, 116, 92, 68, 245, 114, 30, 14, 106, 232, 197, 149, 34, 49, 249, 103, 102, 149, 13, 209, 213, 106, 91, 130, 183, 138, 18, 123, 251, 212, 239, 42, 212, 147, 77, 95, 54, 217, 81, 52, 46, 170, 74, 117, 0, 192, 14, 114, 72, 33, 193, 130, 148, 226, 136, 115, 102, 170, 37, 153, 250, 119 }, new byte[] { 63, 213, 98, 76, 123, 241, 30, 223, 186, 37, 193, 84, 58, 203, 249, 60, 72, 167, 135, 114, 187, 103, 67, 224, 155, 126, 98, 190, 204, 123, 246, 101, 94, 238, 17, 155, 47, 214, 184, 104, 62, 107, 234, 125, 28, 134, 254, 186, 224, 69, 229, 45, 147, 109, 221, 20, 0, 246, 225, 224, 22, 192, 26, 121, 30, 167, 99, 71, 194, 124, 218, 235, 2, 16, 100, 217, 116, 55, 255, 34, 213, 172, 234, 45, 216, 243, 220, 239, 167, 114, 57, 85, 198, 34, 59, 205, 250, 36, 158, 81, 68, 116, 83, 82, 99, 55, 224, 41, 17, 227, 188, 36, 113, 152, 5, 182, 127, 189, 114, 100, 196, 187, 91, 103, 51, 218, 59, 26 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 5, 16, 43, 53, 282, DateTimeKind.Local).AddTicks(1746), new byte[] { 5, 105, 88, 174, 85, 74, 105, 183, 178, 178, 158, 65, 111, 23, 14, 168, 140, 88, 131, 164, 139, 27, 150, 64, 166, 186, 166, 150, 106, 78, 254, 232, 246, 52, 94, 249, 17, 50, 119, 57, 193, 32, 195, 142, 153, 181, 143, 90, 249, 129, 133, 196, 183, 77, 115, 1, 124, 162, 123, 177, 35, 234, 158, 213 }, new byte[] { 138, 8, 33, 85, 100, 135, 49, 65, 179, 77, 37, 87, 77, 213, 116, 200, 1, 116, 160, 105, 27, 89, 188, 172, 1, 158, 110, 14, 187, 76, 226, 50, 218, 207, 95, 195, 227, 188, 28, 112, 51, 200, 6, 95, 65, 34, 128, 114, 217, 222, 97, 22, 132, 204, 100, 227, 255, 142, 124, 232, 20, 38, 95, 188, 145, 33, 67, 191, 135, 185, 80, 178, 46, 9, 77, 210, 175, 127, 113, 186, 109, 5, 81, 238, 226, 0, 30, 185, 98, 250, 98, 28, 226, 168, 32, 178, 247, 207, 33, 24, 254, 217, 37, 241, 46, 58, 6, 50, 182, 205, 45, 24, 135, 145, 94, 161, 241, 202, 105, 134, 191, 63, 53, 70, 138, 209, 255, 53 } });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Shelves_CurrentShelfId",
                table: "BookCopies",
                column: "CurrentShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Users_CurrentUserId",
                table: "BookCopies",
                column: "CurrentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
