using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedShelvesAddressFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Shelves");

            migrationBuilder.AddColumn<string>(
                name: "FormattedAddress",
                table: "Shelves",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Shelves",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Shelves",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 5, 14, 29, 37, 381, DateTimeKind.Local).AddTicks(9076), new byte[] { 253, 141, 102, 47, 224, 26, 204, 5, 46, 118, 53, 155, 51, 112, 189, 194, 178, 85, 172, 130, 159, 37, 140, 134, 149, 82, 167, 67, 250, 46, 139, 86, 77, 2, 77, 64, 82, 91, 148, 70, 72, 136, 185, 55, 67, 233, 242, 89, 10, 231, 90, 207, 214, 249, 89, 62, 129, 109, 39, 139, 77, 42, 55, 103 }, new byte[] { 95, 64, 231, 106, 11, 33, 158, 86, 21, 104, 254, 68, 129, 60, 166, 99, 148, 41, 217, 245, 176, 78, 181, 209, 19, 220, 198, 110, 251, 253, 166, 81, 120, 171, 103, 19, 141, 1, 246, 232, 136, 178, 127, 209, 6, 163, 135, 170, 103, 204, 156, 5, 115, 4, 22, 107, 73, 26, 6, 97, 16, 129, 228, 29, 101, 186, 94, 82, 233, 247, 129, 21, 189, 159, 95, 6, 24, 9, 75, 81, 26, 6, 86, 29, 100, 6, 171, 5, 230, 250, 70, 216, 56, 114, 72, 200, 138, 253, 231, 136, 253, 212, 29, 189, 71, 75, 28, 224, 129, 129, 69, 180, 12, 19, 32, 148, 140, 86, 210, 16, 217, 30, 47, 183, 90, 87, 113, 138 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 5, 14, 29, 37, 381, DateTimeKind.Local).AddTicks(9139), new byte[] { 203, 76, 93, 142, 78, 145, 237, 43, 117, 90, 87, 124, 170, 131, 241, 154, 62, 172, 52, 247, 166, 14, 129, 45, 143, 120, 66, 214, 46, 179, 231, 173, 0, 143, 186, 173, 165, 1, 123, 43, 60, 199, 144, 54, 172, 235, 16, 229, 38, 28, 5, 60, 138, 137, 54, 137, 175, 195, 245, 62, 201, 166, 218, 176 }, new byte[] { 63, 60, 169, 25, 185, 32, 242, 103, 85, 74, 219, 82, 148, 48, 128, 38, 103, 160, 76, 142, 116, 193, 91, 140, 111, 176, 154, 79, 62, 25, 10, 135, 238, 103, 254, 174, 73, 37, 163, 75, 79, 130, 118, 235, 201, 43, 168, 100, 153, 182, 145, 245, 184, 81, 1, 78, 218, 73, 109, 171, 135, 252, 124, 244, 255, 204, 169, 90, 59, 99, 178, 6, 220, 158, 193, 53, 44, 13, 9, 217, 189, 5, 140, 197, 13, 226, 33, 67, 242, 72, 61, 220, 206, 122, 54, 190, 243, 63, 119, 148, 28, 124, 213, 197, 21, 47, 82, 208, 105, 113, 199, 244, 214, 238, 131, 133, 154, 145, 49, 235, 75, 150, 116, 116, 40, 132, 14, 167 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormattedAddress",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Shelves");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Shelves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4615), new byte[] { 220, 207, 220, 235, 226, 197, 247, 125, 191, 200, 244, 104, 246, 245, 93, 49, 192, 144, 83, 121, 145, 224, 80, 211, 105, 166, 52, 28, 238, 1, 148, 167, 223, 122, 228, 149, 20, 27, 167, 58, 2, 210, 208, 146, 31, 65, 252, 165, 203, 240, 13, 220, 244, 45, 204, 10, 34, 236, 40, 188, 79, 131, 97, 46 }, new byte[] { 246, 233, 52, 119, 248, 141, 85, 55, 32, 214, 136, 240, 40, 29, 58, 120, 200, 10, 81, 211, 226, 174, 38, 4, 153, 198, 34, 44, 1, 57, 59, 194, 45, 91, 140, 0, 107, 17, 53, 199, 27, 214, 193, 10, 57, 42, 99, 215, 54, 184, 225, 117, 218, 145, 96, 8, 153, 123, 41, 28, 194, 28, 38, 12, 19, 158, 253, 40, 55, 232, 179, 207, 145, 240, 119, 69, 221, 62, 115, 239, 255, 24, 208, 138, 28, 99, 144, 121, 134, 109, 70, 158, 9, 116, 173, 178, 194, 131, 206, 87, 165, 230, 28, 47, 47, 95, 27, 95, 8, 134, 174, 108, 20, 61, 106, 248, 178, 30, 32, 10, 154, 7, 8, 52, 59, 255, 8, 204 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4682), new byte[] { 238, 180, 162, 178, 1, 247, 89, 118, 103, 125, 161, 58, 131, 132, 174, 203, 108, 97, 82, 252, 113, 229, 3, 159, 221, 216, 53, 29, 156, 178, 82, 188, 75, 15, 192, 111, 22, 142, 163, 118, 206, 196, 119, 62, 167, 109, 27, 131, 157, 168, 228, 139, 118, 202, 10, 226, 203, 222, 242, 17, 251, 46, 214, 41 }, new byte[] { 7, 233, 48, 16, 15, 252, 138, 161, 239, 182, 216, 185, 105, 8, 66, 222, 44, 162, 177, 10, 246, 139, 144, 47, 10, 108, 51, 216, 15, 123, 248, 18, 214, 195, 249, 41, 235, 245, 7, 31, 75, 14, 19, 227, 69, 62, 219, 148, 144, 82, 225, 241, 172, 231, 2, 232, 46, 1, 208, 1, 105, 145, 38, 192, 64, 74, 107, 170, 169, 177, 226, 230, 118, 246, 169, 241, 33, 199, 217, 65, 128, 7, 185, 193, 235, 250, 233, 227, 73, 45, 150, 90, 57, 7, 121, 14, 200, 82, 231, 130, 29, 214, 207, 88, 30, 189, 216, 85, 214, 41, 151, 169, 186, 24, 50, 58, 74, 160, 219, 32, 251, 215, 33, 143, 46, 137, 61, 196 } });
        }
    }
}
