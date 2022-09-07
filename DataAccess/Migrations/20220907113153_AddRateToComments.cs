﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRateToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Comments");

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
    }
}