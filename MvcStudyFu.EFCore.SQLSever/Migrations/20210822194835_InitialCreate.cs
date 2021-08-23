using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStudyFu.EFCore.SQLSever.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyType",
                columns: table => new
                {
                    StudyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyType", x => x.StudyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Account = table.Column<decimal>(type: "decimal(20,0)", maxLength: 20, nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QQ = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Hobby = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studyknowledge",
                columns: table => new
                {
                    StudyknowledgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyknowledgeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudyknowledgeContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studyknowledge", x => x.StudyknowledgeId);
                    table.ForeignKey(
                        name: "FK_Studyknowledge_StudyType_StudyTypeId",
                        column: x => x.StudyTypeId,
                        principalTable: "StudyType",
                        principalColumn: "StudyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPassword",
                columns: table => new
                {
                    UserPasswordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewPassword = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastPassword = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassword", x => x.UserPasswordId);
                    table.ForeignKey(
                        name: "FK_UserPassword_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StudyType",
                columns: new[] { "StudyTypeId", "StudyTypeName" },
                values: new object[,]
                {
                    { 1, "前端" },
                    { 2, "后端" },
                    { 3, "数据库" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("095823f4-f8cd-4310-b67e-46d3cb46ed66"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Do Love", null, "小杰", null, null });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("3861259c-9557-4f36-a0cc-820b64d41ad0"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("095823f4-f8cd-4310-b67e-46d3cb46ed66") });

            migrationBuilder.CreateIndex(
                name: "IX_Studyknowledge_StudyTypeId",
                table: "Studyknowledge",
                column: "StudyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassword_UserId",
                table: "UserPassword",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studyknowledge");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "StudyType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
