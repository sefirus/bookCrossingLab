using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPicturesToBookCopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCopyId",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 10, 12, 10, 13, 199, DateTimeKind.Local).AddTicks(4609), new byte[] { 5, 236, 179, 15, 31, 17, 168, 235, 155, 177, 98, 212, 89, 115, 133, 208, 4, 155, 120, 172, 23, 2, 22, 224, 169, 53, 84, 0, 177, 8, 18, 71, 35, 190, 115, 74, 111, 252, 175, 7, 50, 235, 92, 236, 27, 55, 117, 77, 147, 153, 75, 85, 129, 170, 67, 134, 74, 30, 230, 45, 172, 10, 103, 160 }, new byte[] { 15, 35, 121, 241, 31, 113, 175, 172, 139, 21, 225, 143, 48, 248, 35, 214, 97, 192, 42, 213, 86, 176, 63, 246, 170, 127, 93, 177, 195, 7, 175, 200, 120, 156, 19, 133, 33, 255, 86, 42, 139, 211, 166, 61, 86, 61, 208, 247, 192, 5, 169, 9, 220, 189, 158, 98, 26, 247, 241, 255, 79, 85, 220, 49, 153, 4, 80, 3, 115, 74, 68, 77, 81, 12, 47, 241, 61, 128, 194, 145, 229, 207, 172, 152, 27, 183, 38, 126, 205, 225, 161, 12, 128, 3, 40, 83, 173, 107, 198, 193, 213, 56, 13, 168, 148, 113, 93, 121, 60, 55, 245, 146, 195, 125, 44, 209, 84, 2, 92, 131, 247, 183, 57, 222, 28, 43, 102, 198 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 10, 12, 10, 13, 199, DateTimeKind.Local).AddTicks(4676), new byte[] { 74, 90, 27, 90, 150, 210, 229, 117, 118, 129, 162, 149, 146, 31, 66, 57, 120, 211, 181, 101, 210, 129, 245, 246, 74, 76, 1, 154, 221, 171, 240, 79, 74, 232, 172, 33, 131, 153, 132, 76, 44, 65, 163, 248, 59, 121, 221, 78, 165, 111, 23, 174, 52, 62, 24, 101, 227, 239, 100, 250, 248, 7, 23, 216 }, new byte[] { 157, 133, 207, 196, 110, 43, 112, 232, 153, 147, 38, 83, 254, 26, 84, 104, 104, 120, 194, 206, 222, 77, 216, 73, 79, 5, 18, 9, 243, 103, 151, 199, 149, 55, 223, 102, 100, 110, 169, 210, 135, 157, 21, 67, 15, 71, 189, 228, 152, 41, 68, 109, 121, 11, 234, 169, 43, 90, 129, 35, 60, 23, 44, 106, 243, 146, 103, 228, 237, 175, 124, 63, 190, 5, 67, 205, 48, 87, 228, 39, 29, 117, 0, 28, 105, 116, 105, 50, 239, 193, 179, 160, 23, 117, 252, 84, 178, 34, 200, 26, 21, 245, 149, 76, 30, 149, 187, 90, 131, 222, 100, 43, 7, 121, 12, 231, 105, 66, 254, 37, 119, 181, 154, 247, 192, 61, 66, 199 } });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_BookCopyId",
                table: "Pictures",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_BookCopies_BookCopyId",
                table: "Pictures",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_BookCopies_BookCopyId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_BookCopyId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "Pictures");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 31, 53, 250, DateTimeKind.Local).AddTicks(9964), new byte[] { 170, 47, 219, 64, 218, 56, 20, 239, 230, 32, 228, 166, 40, 100, 33, 15, 36, 212, 62, 233, 140, 155, 171, 140, 89, 3, 104, 54, 180, 226, 124, 30, 108, 181, 183, 71, 104, 78, 192, 107, 216, 145, 181, 214, 196, 94, 171, 71, 59, 248, 251, 212, 188, 0, 250, 88, 149, 88, 183, 144, 55, 44, 194, 160 }, new byte[] { 69, 45, 206, 144, 238, 30, 243, 250, 193, 57, 177, 137, 240, 239, 80, 97, 19, 161, 121, 55, 31, 244, 219, 219, 31, 105, 113, 69, 194, 236, 115, 45, 203, 199, 65, 133, 26, 214, 134, 85, 89, 217, 197, 14, 10, 47, 244, 148, 51, 144, 102, 64, 152, 28, 124, 106, 171, 143, 80, 62, 168, 181, 80, 233, 168, 123, 245, 114, 243, 27, 61, 235, 213, 164, 9, 157, 171, 107, 237, 223, 197, 192, 124, 122, 9, 199, 29, 174, 197, 113, 183, 56, 132, 213, 51, 239, 156, 10, 47, 58, 8, 155, 68, 20, 99, 216, 82, 55, 130, 67, 88, 4, 185, 220, 167, 77, 68, 35, 94, 190, 109, 110, 252, 134, 253, 119, 80, 244 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 31, 53, 251, DateTimeKind.Local).AddTicks(33), new byte[] { 114, 160, 76, 115, 17, 108, 28, 80, 107, 62, 243, 245, 239, 93, 202, 39, 117, 70, 214, 68, 113, 185, 72, 109, 108, 234, 48, 237, 17, 132, 200, 24, 155, 156, 8, 111, 118, 68, 243, 94, 92, 9, 202, 227, 111, 137, 162, 156, 5, 165, 239, 202, 163, 74, 50, 41, 23, 236, 229, 242, 102, 5, 8, 171 }, new byte[] { 74, 91, 110, 71, 1, 182, 79, 59, 200, 243, 102, 97, 76, 198, 215, 148, 156, 131, 130, 39, 232, 167, 91, 21, 157, 125, 187, 77, 67, 236, 32, 136, 24, 172, 79, 96, 43, 69, 18, 224, 68, 129, 246, 221, 182, 191, 2, 3, 139, 27, 59, 38, 200, 101, 198, 98, 172, 70, 118, 67, 106, 147, 46, 19, 36, 234, 15, 187, 144, 3, 134, 189, 169, 211, 3, 206, 44, 253, 64, 157, 241, 196, 231, 59, 163, 150, 53, 68, 90, 158, 37, 245, 222, 242, 150, 38, 142, 208, 160, 187, 246, 21, 31, 93, 27, 11, 182, 17, 124, 23, 108, 93, 98, 165, 179, 37, 122, 69, 77, 5, 181, 190, 216, 95, 38, 137, 252, 42 } });
        }
    }
}
