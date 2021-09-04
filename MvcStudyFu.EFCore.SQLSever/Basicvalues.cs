using MvcStudyFu.Common;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.EFCore.SQLSever
{
    public static class Basicvalues
    {
        public static ConcurrentDictionary<string, Guid> GetGuid()
        {
            ConcurrentDictionary<string, Guid> keyValues = new();
            var userGuid = Guid.NewGuid();   //统治者Guid
            var userPasswordGuid = Guid.NewGuid();  //统治者密码Guid
            var personalGuid = Guid.NewGuid();  //个人管理Guid
            var systemGuid = Guid.NewGuid();   //系统管理Guid
            var personalInfomGuid = Guid.NewGuid();   //个人信息Guid
            var studyknowledgeGuid = Guid.NewGuid();   //学习数据Guid
            var journalGuid = Guid.NewGuid();   //日志记录Guid
            var userManageGuid = Guid.NewGuid();   //用户管理Guid
            var roleGuid = Guid.NewGuid();   //角色管理Guid
            var permissionsGuid = Guid.NewGuid();   //权限管理Guid

            var goverorGuid = Guid.NewGuid();   //统治者Guid
            var generalGuid = Guid.NewGuid();   //大将Guid
            var bitPartGuid = Guid.NewGuid();   //虾兵蟹将Guid

            keyValues.GetOrAdd("userGuid", userGuid);
            keyValues.GetOrAdd("userPasswordGuid", userPasswordGuid);

            keyValues.GetOrAdd("personalGuid", personalGuid);
            keyValues.GetOrAdd("systemGuid", systemGuid);
            keyValues.GetOrAdd("personalInfomGuid", personalInfomGuid);
            keyValues.GetOrAdd("studyknowledgeGuid", studyknowledgeGuid);
            keyValues.GetOrAdd("journalGuid", journalGuid);
            keyValues.GetOrAdd("userManageGuid", userManageGuid);
            keyValues.GetOrAdd("roleGuid", roleGuid);
            keyValues.GetOrAdd("permissionsGuid", permissionsGuid);

            keyValues.GetOrAdd("goverorGuid", goverorGuid);
            keyValues.GetOrAdd("generalGuid", generalGuid);
            keyValues.GetOrAdd("bitPartGuid", bitPartGuid);

            return keyValues;
        }

        public static ConcurrentDictionary<string, object> GetList(ConcurrentDictionary<string, Guid> keyValues)
        {
            ConcurrentDictionary<string, object> Values = new();

            List<User> users = new(); //初始用户拥有一切权限
            List<UserPassword> userPasswords = new();//初始用户密码
            List<StudyType> studyTypes = new()
            {
                new StudyType() { StudyTypeId = 1, StudyTypeName = "前端" },
                new StudyType() { StudyTypeId = 2, StudyTypeName = "后端" },
                new StudyType() { StudyTypeId = 3, StudyTypeName = "数据库" }
            };
            List<Resource> resources = new(); //资源表初始值
            List<Role> roles = new()
            {
                new Role
                {
                    RoleId = keyValues["goverorGuid"],
                    RoleName = "统治者",
                    RoleDescribe = "拥有一切权利"
                },
                new Role
                {
                    RoleId = keyValues["generalGuid"],
                    RoleName = "大将",
                    RoleDescribe = "没有改变权限的能力"
                },
                new Role
                {
                    RoleId = keyValues["bitPartGuid"],
                    RoleName = "平民",
                    RoleDescribe = "基本功能的使用"
                }
            };    //角色初始值
            List<UserRole> userRoles = new()
            {
                new UserRole
                {
                    RoleId = keyValues["goverorGuid"],
                    UserId = keyValues["userGuid"],
                    UserRoleId = Guid.NewGuid()
                }
            };   //给一个用户全部权限
            List<RoleResouce> roleResouces = new()
            {
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["personalGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["systemGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["personalInfomGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["studyknowledgeGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["journalGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["userManageGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["roleGuid"],
                    RoleId = keyValues["goverorGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["permissionsGuid"],
                    RoleId = keyValues["goverorGuid"]
                },

                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["systemGuid"],
                    RoleId = keyValues["generalGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["personalInfomGuid"],
                    RoleId = keyValues["generalGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["studyknowledgeGuid"],
                    RoleId = keyValues["generalGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["journalGuid"],
                    RoleId = keyValues["generalGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["userManageGuid"],
                    RoleId = keyValues["generalGuid"]
                },



                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["personalGuid"],
                    RoleId = keyValues["bitPartGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["systemGuid"],
                    RoleId = keyValues["bitPartGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["personalInfomGuid"],
                    RoleId = keyValues["bitPartGuid"]
                },
                new RoleResouce
                {
                    RoleResouceId = Guid.NewGuid(),
                    ResourceId = keyValues["studyknowledgeGuid"],
                    RoleId = keyValues["bitPartGuid"]
                },


            }; //不同角色对应的权限


            var emptyUser = new User()
            {
                Account = 1314520,
                Id = keyValues["userGuid"],
                Name = "小杰",
                Birthday = new DateTime(2001, 11, 18),
                Hobby = "Do Love",
                IsDel = true,
                QQ = 1328703932,
                Moblie = "15014080506",
                Email = "1328703932@qq.com"
                ,Sex=true
            };
            var emptyUserPassword = new UserPassword()
            {
                UserPasswordId = keyValues["userPasswordGuid"],
                NewPassword = "123456".ToMD5(),
                UserId = keyValues["userGuid"]
            };
            var oneResource = new List<Resource>() {
             new Resource
                {
                    Icon = "el-icon-user-solid",
                    Level = 0,
                    ParentId = null,
                    Path = "",
                    ResourceId =keyValues["personalGuid"],
                    ResourceName = "个人管理",
                    Sort = 0
                },
             new Resource
                {
                    Icon = "el-icon-s-tools",
                    Level = 0,
                    ParentId = null,
                    Path = "",
                    ResourceId =keyValues["systemGuid"],
                    ResourceName = "系统管理",
                    Sort = 1
                }
            }; //一级菜单
            var twoResource = new List<Resource>() {
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId = keyValues["personalGuid"],
                    Path = "/PersonalInfo/Index",
                    ResourceId =keyValues["personalInfomGuid"],
                    ResourceName = "个人信息",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId =keyValues["personalGuid"],
                    Path = "/Study/Studyknowledge",
                    ResourceId = keyValues["studyknowledgeGuid"],
                    ResourceName = "学习数据",
                    Sort = 1
                },
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId = keyValues["personalGuid"],
                    Path = "/Journal/Index",
                    ResourceId =keyValues["journalGuid"],
                    ResourceName = "日志记录",
                    Sort = 2
                },
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId = keyValues["systemGuid"],
                    Path = "/UserManage/Index",
                    ResourceId = keyValues["userManageGuid"],
                    ResourceName = "用户管理",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId =keyValues["systemGuid"],
                    Path = "/Role/Index",
                    ResourceId = keyValues["roleGuid"],
                    ResourceName = "角色管理",
                    Sort = 1
                },
                new Resource
                {
                    Icon = "el-icon-s-grid",
                    Level = 1,
                    ParentId =keyValues["systemGuid"],
                    Path = "/Permissions/index",
                    ResourceId = keyValues["permissionsGuid"],
                    ResourceName = "权限管理",
                    Sort = 2
                }
            }; //二级菜单

            users.Add(emptyUser);
            userPasswords.Add(emptyUserPassword);
            resources.AddRange(oneResource);
            resources.AddRange(twoResource);

            Values.GetOrAdd("users", users);
            Values.GetOrAdd("userPasswords", userPasswords);
            Values.GetOrAdd("studyTypes", studyTypes);
            Values.GetOrAdd("resources", resources);
            Values.GetOrAdd("roles", roles);
            Values.GetOrAdd("userRoles", userRoles);
            Values.GetOrAdd("roleResouces", roleResouces);
            return Values;
        }
    }
}