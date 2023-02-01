using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRepoDecorator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Shelves",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FormattedAddress",
                table: "Shelves",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Publishers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 2, 1, 20, 29, 48, 337, DateTimeKind.Local).AddTicks(6453), new byte[] { 57, 63, 162, 248, 86, 89, 138, 252, 229, 94, 110, 131, 235, 31, 221, 0, 138, 122, 31, 155, 60, 232, 118, 13, 154, 41, 91, 135, 107, 137, 199, 16, 96, 52, 70, 118, 34, 92, 188, 6, 84, 27, 207, 52, 238, 155, 60, 191, 67, 168, 54, 247, 123, 90, 119, 168, 108, 39, 51, 252, 217, 63, 253, 46 }, new byte[] { 22, 40, 108, 76, 252, 240, 0, 12, 148, 46, 148, 181, 134, 33, 203, 220, 73, 217, 127, 249, 247, 81, 29, 83, 195, 77, 9, 83, 95, 17, 26, 17, 65, 215, 222, 98, 104, 29, 99, 82, 169, 68, 80, 201, 99, 234, 154, 199, 60, 48, 61, 99, 200, 61, 65, 48, 53, 111, 243, 98, 196, 10, 53, 46, 226, 158, 234, 239, 160, 1, 44, 119, 248, 197, 129, 141, 245, 186, 30, 171, 46, 253, 7, 32, 1, 223, 31, 165, 106, 203, 69, 197, 97, 62, 95, 128, 170, 156, 4, 102, 40, 163, 29, 252, 165, 95, 165, 202, 109, 49, 169, 82, 215, 52, 69, 179, 9, 200, 109, 17, 125, 18, 146, 61, 82, 158, 229, 75 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 2, 1, 20, 29, 48, 337, DateTimeKind.Local).AddTicks(6562), new byte[] { 196, 235, 218, 178, 232, 94, 90, 197, 105, 66, 179, 101, 186, 74, 81, 155, 248, 64, 233, 214, 69, 129, 38, 234, 253, 46, 187, 179, 149, 117, 96, 156, 47, 126, 168, 151, 195, 180, 66, 181, 184, 236, 229, 229, 132, 85, 86, 101, 187, 208, 204, 27, 63, 85, 212, 8, 231, 179, 228, 173, 212, 54, 239, 161 }, new byte[] { 38, 117, 11, 132, 133, 91, 119, 22, 248, 48, 60, 188, 229, 102, 208, 244, 131, 109, 164, 125, 245, 68, 40, 117, 81, 182, 7, 23, 139, 201, 16, 39, 142, 138, 232, 110, 61, 181, 200, 208, 244, 147, 140, 21, 122, 65, 187, 77, 77, 59, 218, 40, 149, 14, 148, 5, 84, 67, 32, 83, 156, 147, 63, 18, 119, 14, 202, 109, 212, 152, 231, 12, 53, 189, 128, 138, 94, 6, 171, 157, 230, 167, 81, 213, 9, 215, 124, 34, 93, 145, 14, 82, 21, 184, 232, 38, 125, 219, 238, 43, 224, 22, 237, 222, 169, 44, 234, 173, 128, 180, 215, 67, 132, 208, 241, 230, 140, 157, 224, 3, 62, 79, 99, 126, 31, 233, 217, 109 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Shelves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FormattedAddress",
                table: "Shelves",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 10, 17, 2, 54, 528, DateTimeKind.Local).AddTicks(408), new byte[] { 238, 233, 157, 208, 53, 117, 159, 31, 127, 12, 213, 160, 10, 219, 107, 218, 73, 215, 72, 192, 113, 255, 184, 82, 209, 33, 146, 91, 127, 123, 171, 167, 161, 200, 222, 210, 32, 54, 103, 193, 130, 248, 158, 130, 127, 228, 46, 210, 237, 99, 121, 30, 222, 156, 214, 77, 138, 130, 130, 107, 28, 110, 192, 63 }, new byte[] { 82, 209, 97, 216, 121, 121, 160, 208, 138, 140, 76, 237, 207, 144, 215, 239, 146, 218, 10, 154, 201, 97, 31, 6, 235, 30, 97, 200, 186, 218, 243, 133, 202, 18, 45, 211, 98, 151, 43, 183, 44, 231, 217, 131, 127, 242, 208, 84, 124, 49, 76, 171, 37, 208, 235, 30, 14, 13, 88, 251, 188, 186, 81, 110, 129, 245, 132, 14, 55, 191, 126, 42, 129, 239, 4, 13, 132, 95, 96, 139, 223, 77, 90, 172, 158, 185, 115, 72, 50, 90, 239, 94, 6, 230, 243, 177, 65, 239, 141, 117, 253, 199, 247, 37, 70, 141, 168, 230, 20, 189, 24, 135, 236, 253, 146, 47, 46, 229, 66, 116, 129, 191, 14, 195, 161, 68, 208, 90 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 10, 17, 2, 54, 528, DateTimeKind.Local).AddTicks(475), new byte[] { 144, 24, 112, 7, 138, 130, 71, 168, 146, 248, 35, 19, 39, 199, 127, 59, 19, 154, 246, 12, 244, 75, 128, 19, 232, 247, 77, 29, 189, 58, 63, 61, 130, 215, 175, 94, 202, 45, 75, 121, 117, 33, 36, 143, 108, 179, 59, 128, 114, 204, 121, 116, 64, 40, 48, 161, 204, 246, 75, 80, 186, 6, 255, 153 }, new byte[] { 70, 98, 4, 18, 97, 207, 219, 126, 228, 114, 154, 14, 177, 25, 229, 11, 132, 157, 102, 77, 137, 46, 200, 215, 72, 179, 243, 178, 73, 46, 11, 77, 208, 223, 251, 40, 58, 141, 166, 100, 106, 48, 108, 147, 2, 37, 161, 240, 82, 101, 26, 103, 196, 54, 120, 6, 144, 86, 203, 135, 231, 188, 246, 147, 8, 92, 214, 65, 81, 98, 236, 190, 226, 236, 64, 203, 171, 89, 14, 101, 126, 55, 43, 10, 9, 212, 150, 232, 207, 6, 149, 114, 247, 128, 225, 110, 10, 15, 51, 26, 82, 8, 68, 149, 62, 0, 52, 39, 134, 63, 22, 156, 168, 3, 116, 222, 185, 188, 167, 162, 139, 193, 170, 127, 73, 243, 177, 210 } });
        }
    }
}
