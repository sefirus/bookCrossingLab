using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePictureId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowCurrentBooks",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "POWER USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "USER" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "ProfilePictureId", "RoleId", "ShowCurrentBooks" },
                values: new object[] { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4615), "admin@email.com", "Super", true, "Admin", new byte[] { 220, 207, 220, 235, 226, 197, 247, 125, 191, 200, 244, 104, 246, 245, 93, 49, 192, 144, 83, 121, 145, 224, 80, 211, 105, 166, 52, 28, 238, 1, 148, 167, 223, 122, 228, 149, 20, 27, 167, 58, 2, 210, 208, 146, 31, 65, 252, 165, 203, 240, 13, 220, 244, 45, 204, 10, 34, 236, 40, 188, 79, 131, 97, 46 }, new byte[] { 246, 233, 52, 119, 248, 141, 85, 55, 32, 214, 136, 240, 40, 29, 58, 120, 200, 10, 81, 211, 226, 174, 38, 4, 153, 198, 34, 44, 1, 57, 59, 194, 45, 91, 140, 0, 107, 17, 53, 199, 27, 214, 193, 10, 57, 42, 99, 215, 54, 184, 225, 117, 218, 145, 96, 8, 153, 123, 41, 28, 194, 28, 38, 12, 19, 158, 253, 40, 55, 232, 179, 207, 145, 240, 119, 69, 221, 62, 115, 239, 255, 24, 208, 138, 28, 99, 144, 121, 134, 109, 70, 158, 9, 116, 173, 178, 194, 131, 206, 87, 165, 230, 28, 47, 47, 95, 27, 95, 8, 134, 174, 108, 20, 61, 106, 248, 178, 30, 32, 10, 154, 7, 8, 52, 59, 255, 8, 204 }, null, 1, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "ProfilePictureId", "RoleId", "ShowCurrentBooks" },
                values: new object[] { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 3, 22, 36, 40, 390, DateTimeKind.Local).AddTicks(4682), "powerUser@email.com", "Power", true, "User", new byte[] { 238, 180, 162, 178, 1, 247, 89, 118, 103, 125, 161, 58, 131, 132, 174, 203, 108, 97, 82, 252, 113, 229, 3, 159, 221, 216, 53, 29, 156, 178, 82, 188, 75, 15, 192, 111, 22, 142, 163, 118, 206, 196, 119, 62, 167, 109, 27, 131, 157, 168, 228, 139, 118, 202, 10, 226, 203, 222, 242, 17, 251, 46, 214, 41 }, new byte[] { 7, 233, 48, 16, 15, 252, 138, 161, 239, 182, 216, 185, 105, 8, 66, 222, 44, 162, 177, 10, 246, 139, 144, 47, 10, 108, 51, 216, 15, 123, 248, 18, 214, 195, 249, 41, 235, 245, 7, 31, 75, 14, 19, 227, 69, 62, 219, 148, 144, 82, 225, 241, 172, 231, 2, 232, 46, 1, 208, 1, 105, 145, 38, 192, 64, 74, 107, 170, 169, 177, 226, 230, 118, 246, 169, 241, 33, 199, 217, 65, 128, 7, 185, 193, 235, 250, 233, 227, 73, 45, 150, 90, 57, 7, 121, 14, 200, 82, 231, 130, 29, 214, 207, 88, 30, 189, 216, 85, 214, 41, 151, 169, 186, 24, 50, 58, 74, 160, 219, 32, 251, 215, 33, 143, 46, 137, 61, 196 }, null, 2, true });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShowCurrentBooks",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePictureId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId",
                unique: true);
        }
    }
}
