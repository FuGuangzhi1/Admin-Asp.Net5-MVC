using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStudyFu.EFCore.SQLSever.Migrations
{
    public partial class InitialCreate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPassword",
                keyColumn: "UserPasswordId",
                keyValue: new Guid("3861259c-9557-4f36-a0cc-820b64d41ad0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("095823f4-f8cd-4310-b67e-46d3cb46ed66"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDel",
                table: "User",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<long>(type: "bigint", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescribe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoleResouce",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleResouceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleResouce", x => new { x.RoleId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_RoleResouce_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleResouce_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "IsDel", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Do Love", null, null, "小杰", null, null });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("e0e5f5d2-42e5-488f-a28b-e84e094276db"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleResouce_ResourceId",
                table: "RoleResouce",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleResouce");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DeleteData(
                table: "UserPassword",
                keyColumn: "UserPasswordId",
                keyValue: new Guid("e0e5f5d2-42e5-488f-a28b-e84e094276db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365"));

            migrationBuilder.DropColumn(
                name: "IsDel",
                table: "User");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("095823f4-f8cd-4310-b67e-46d3cb46ed66"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Do Love", null, "小杰", null, null });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("3861259c-9557-4f36-a0cc-820b64d41ad0"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("095823f4-f8cd-4310-b67e-46d3cb46ed66") });
        }
    }
}
