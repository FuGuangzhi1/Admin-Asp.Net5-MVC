using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStudyFu.EFCore.SQLSever.Migrations
{
    public partial class InitialCreate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPassword",
                keyColumn: "UserPasswordId",
                keyValue: new Guid("e0e5f5d2-42e5-488f-a28b-e84e094276db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365"));

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ResourceId", "Icon", "Level", "ParentId", "Path", "ResourceName", "Sort" },
                values: new object[,]
                {
                    { new Guid("ff7eea02-6e3f-494e-bab5-89cbfb2f6111"), "el-icon-user-solid", 0L, null, "", "个人管理", 0 },
                    { new Guid("da2a83b3-89d2-4cb9-8458-3e1150539a87"), "el-icon-s-tools", 0L, null, "", "系统管理", 1 },
                    { new Guid("f1ea2857-30db-49b5-8498-27e51b27f8ed"), "el-icon-s-grid", 1L, new Guid("ff7eea02-6e3f-494e-bab5-89cbfb2f6111"), "/PersonalInfo/Index", "个人信息", 0 },
                    { new Guid("1fb137a3-8e02-43bf-9a98-c8665f02d145"), "el-icon-s-grid", 1L, new Guid("ff7eea02-6e3f-494e-bab5-89cbfb2f6111"), "/Study/Studyknowledge", "学习数据", 1 },
                    { new Guid("110fa9e0-4d9c-425d-b6a5-c5426fa7d2ff"), "el-icon-s-grid", 1L, new Guid("ff7eea02-6e3f-494e-bab5-89cbfb2f6111"), "/Journal/Index", "日志记录", 2 },
                    { new Guid("e807cfd4-fb6e-4efa-8d4e-f5efe9734f8e"), "el-icon-s-grid", 1L, new Guid("da2a83b3-89d2-4cb9-8458-3e1150539a87"), "/UserManage/Index", "用户管理", 0 },
                    { new Guid("e1d23ef1-74b4-4677-9c56-4f4c168a6ce2"), "el-icon-s-grid", 1L, new Guid("da2a83b3-89d2-4cb9-8458-3e1150539a87"), "/Role/Index", "角色管理", 1 },
                    { new Guid("648e04bb-2d3e-477e-b2a5-bc807af94dfa"), "el-icon-s-grid", 1L, new Guid("da2a83b3-89d2-4cb9-8458-3e1150539a87"), "/Permissions/index", "权限管理", 2 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleDescribe", "RoleName" },
                values: new object[,]
                {
                    { new Guid("98cec3b9-9913-4ee0-b055-0fdf772395a9"), "拥有一切权利", "统治者" },
                    { new Guid("235e0d66-c040-4adb-ae74-1166ec1f92f3"), "没有改变权限的能力", "大将" },
                    { new Guid("169c0fcd-b2ac-4686-8255-8580edc5dc8f"), "基本功能的使用", "平民" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "IsDel", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("99ce8e1c-dcfc-40d7-910a-0b744f9697a3"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Do Love", null, null, "小杰", null, null });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("4af32f3c-c609-4c7b-a928-febc079d6a68"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("99ce8e1c-dcfc-40d7-910a-0b744f9697a3") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "UserRoleId" },
                values: new object[] { new Guid("98cec3b9-9913-4ee0-b055-0fdf772395a9"), new Guid("99ce8e1c-dcfc-40d7-910a-0b744f9697a3"), new Guid("36bd4625-377f-4331-ab29-333bd3b54cce") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("110fa9e0-4d9c-425d-b6a5-c5426fa7d2ff"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("1fb137a3-8e02-43bf-9a98-c8665f02d145"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("648e04bb-2d3e-477e-b2a5-bc807af94dfa"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("da2a83b3-89d2-4cb9-8458-3e1150539a87"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("e1d23ef1-74b4-4677-9c56-4f4c168a6ce2"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("e807cfd4-fb6e-4efa-8d4e-f5efe9734f8e"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("f1ea2857-30db-49b5-8498-27e51b27f8ed"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ResourceId",
                keyValue: new Guid("ff7eea02-6e3f-494e-bab5-89cbfb2f6111"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("169c0fcd-b2ac-4686-8255-8580edc5dc8f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("235e0d66-c040-4adb-ae74-1166ec1f92f3"));

            migrationBuilder.DeleteData(
                table: "UserPassword",
                keyColumn: "UserPasswordId",
                keyValue: new Guid("4af32f3c-c609-4c7b-a928-febc079d6a68"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("98cec3b9-9913-4ee0-b055-0fdf772395a9"), new Guid("99ce8e1c-dcfc-40d7-910a-0b744f9697a3") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("98cec3b9-9913-4ee0-b055-0fdf772395a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("99ce8e1c-dcfc-40d7-910a-0b744f9697a3"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Birthday", "CreateDateTime", "Email", "Hobby", "IsDel", "Moblie", "Name", "QQ", "UpdateDateTime" },
                values: new object[] { new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365"), 1314520m, new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Do Love", null, null, "小杰", null, null });

            migrationBuilder.InsertData(
                table: "UserPassword",
                columns: new[] { "UserPasswordId", "CreateDateTime", "LastPassword", "NewPassword", "UpdateDateTime", "UserId" },
                values: new object[] { new Guid("e0e5f5d2-42e5-488f-a28b-e84e094276db"), null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, new Guid("8a65bfa2-2063-4357-b0ea-55d6561c7365") });
        }
    }
}
