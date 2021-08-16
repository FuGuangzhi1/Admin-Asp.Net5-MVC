using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStudyFu.EFCore.SQLSever.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CheckCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remeber = table.Column<bool>(type: "bit", maxLength: 20, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserPasswordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                table: "User",
                columns: new[] { "Id", "Account", "CheckCode", "CreateDateTime", "Email", "Moblie", "Name", "QQ", "Remeber", "UpdateDateTime", "UserPasswordId" },
                values: new object[] { new Guid("d62581f6-afa5-4ea8-ab2d-685cb0f3c291"), 1314520m, "", null, null, null, "小杰", null, null, null, new Guid("5c6bb15c-2c43-4714-b1ef-55a0d148238f") });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("5c6bb15c-2c43-4714-b1ef-55a0d148238f"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("d62581f6-afa5-4ea8-ab2d-685cb0f3c291") });

            migrationBuilder.CreateIndex(
                name: "IX_UserPassword_UserId",
                table: "UserPassword",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
