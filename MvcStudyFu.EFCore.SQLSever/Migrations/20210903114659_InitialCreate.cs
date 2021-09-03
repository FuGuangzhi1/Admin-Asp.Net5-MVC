using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStudyFu.EFCore.SQLSever.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                name: "LogRecord",
                columns: table => new
                {
                    LogRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogRecordContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRecord", x => x.LogRecordId);
                    table.ForeignKey(
                        name: "FK_LogRecord_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
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
                table: "Resource",
                columns: new[] { "ResourceId", "Icon", "Level", "ParentId", "Path", "ResourceName", "Sort" },
                values: new object[,]
                {
                    { new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), "el-icon-user-solid", 0L, null, "", "个人管理", 0 },
                    { new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), "el-icon-s-tools", 0L, null, "", "系统管理", 1 },
                    { new Guid("0d56b08c-97a1-41c9-83b5-7fa5831f9804"), "el-icon-s-grid", 1L, new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), "/PersonalInfo/Index", "个人信息", 0 },
                    { new Guid("32da8348-5535-4307-ad22-db8cc0e1aa42"), "el-icon-s-grid", 1L, new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), "/Study/Studyknowledge", "学习数据", 1 },
                    { new Guid("fad0a4a3-b55f-425a-af34-8d0037d7d62a"), "el-icon-s-grid", 1L, new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), "/Journal/Index", "日志记录", 2 },
                    { new Guid("5e247ca8-a8d8-4dd7-bd0a-383e8964b6d6"), "el-icon-s-grid", 1L, new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), "/UserManage/Index", "用户管理", 0 },
                    { new Guid("23952603-1893-490e-be4f-694aed564939"), "el-icon-s-grid", 1L, new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), "/Role/Index", "角色管理", 1 },
                    { new Guid("429cbdef-4c0a-4a69-9cc2-fc2435fe1c9a"), "el-icon-s-grid", 1L, new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), "/Permissions/index", "权限管理", 2 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleDescribe", "RoleName" },
                values: new object[,]
                {
                    { new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), "拥有一切权利", "统治者" },
                    { new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), "没有改变权限的能力", "大将" },
                    { new Guid("d662deff-a947-448e-a669-ae3466de3445"), "基本功能的使用", "平民" }
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
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "IsDel", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("8914cb11-3b03-4842-9c90-22b9ae104be0"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1328703932@qq.com", "Do Love", true, "15014080506", "小杰", 1328703932m, null });

            migrationBuilder.InsertData(
                table: "RoleResouce",
                columns: new[] { "ResourceId", "RoleId", "RoleResouceId" },
                values: new object[,]
                {
                    { new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("d768f21c-fc2a-40d7-b3cf-f02846333fb4") },
                    { new Guid("32da8348-5535-4307-ad22-db8cc0e1aa42"), new Guid("d662deff-a947-448e-a669-ae3466de3445"), new Guid("bc249751-5d88-40f3-944d-be49e4910e25") },
                    { new Guid("0d56b08c-97a1-41c9-83b5-7fa5831f9804"), new Guid("d662deff-a947-448e-a669-ae3466de3445"), new Guid("3237696c-fbe2-4361-85cb-6e346599400a") },
                    { new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), new Guid("d662deff-a947-448e-a669-ae3466de3445"), new Guid("ca9eb305-9b0d-4a9f-b1c8-93cfc52eae6a") },
                    { new Guid("b0ee42f1-0929-4eb3-93ff-73893c10aa79"), new Guid("d662deff-a947-448e-a669-ae3466de3445"), new Guid("c37749ff-a6e4-4108-aeac-d86a406989c1") },
                    { new Guid("5e247ca8-a8d8-4dd7-bd0a-383e8964b6d6"), new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), new Guid("8884b162-73ab-49d7-b2bb-ac37e07c8be4") },
                    { new Guid("fad0a4a3-b55f-425a-af34-8d0037d7d62a"), new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), new Guid("b6001fbd-3615-4998-8e7b-43985451c2df") },
                    { new Guid("32da8348-5535-4307-ad22-db8cc0e1aa42"), new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), new Guid("5d0fac47-6faf-4293-883a-a5dbad588529") },
                    { new Guid("0d56b08c-97a1-41c9-83b5-7fa5831f9804"), new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), new Guid("9ab435c5-141e-4bff-a7bf-d4fafd75d87a") },
                    { new Guid("429cbdef-4c0a-4a69-9cc2-fc2435fe1c9a"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("759a0bbc-4987-4ec5-bb7d-165cadcc5c25") },
                    { new Guid("23952603-1893-490e-be4f-694aed564939"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("b3fdbdbc-c361-469a-aab9-065f40d9d4a3") },
                    { new Guid("5e247ca8-a8d8-4dd7-bd0a-383e8964b6d6"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("98a5721d-3c93-42a0-9d9a-0c0af177c358") },
                    { new Guid("fad0a4a3-b55f-425a-af34-8d0037d7d62a"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("b267ab57-018f-4b95-b1c8-f09ce449f535") },
                    { new Guid("32da8348-5535-4307-ad22-db8cc0e1aa42"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("31db5bfa-7250-44ae-83bb-555df0976838") },
                    { new Guid("0d56b08c-97a1-41c9-83b5-7fa5831f9804"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("f94aa4a7-4e9c-4d7b-8ac5-a8ec323da73e") },
                    { new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("c45d43e9-cff5-40d0-b292-2dceb83078e6") },
                    { new Guid("434ab0a5-2b39-441e-ab84-27d8b19b52ff"), new Guid("c961e2f2-c389-417c-97a8-da94c703ca82"), new Guid("9abf9460-bf24-4fb7-ae9d-c6546b4404aa") }
                });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("eb9e50b0-d946-4801-92c9-cffeed8a075d"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("8914cb11-3b03-4842-9c90-22b9ae104be0") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "UserRoleId" },
                values: new object[] { new Guid("82eba0f4-d30c-4f61-b70b-1c36025552b1"), new Guid("8914cb11-3b03-4842-9c90-22b9ae104be0"), new Guid("91305b5b-1884-43e9-a558-f162d476290c") });

            migrationBuilder.CreateIndex(
                name: "IX_LogRecord_UserId",
                table: "LogRecord",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleResouce_ResourceId",
                table: "RoleResouce",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Studyknowledge_StudyTypeId",
                table: "Studyknowledge",
                column: "StudyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassword_UserId",
                table: "UserPassword",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRecord");

            migrationBuilder.DropTable(
                name: "RoleResouce");

            migrationBuilder.DropTable(
                name: "Studyknowledge");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "StudyType");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
