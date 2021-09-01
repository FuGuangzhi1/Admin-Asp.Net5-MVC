using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.Common;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace MvcStudyFu.EFCore.SQLSever
{
    //Add-Migration InitialCreate数据迁移
    //Update-Database CodeFirst
    public class StudyMVCDBContext : DbContext
    {
        private string _strConn;
        public StudyMVCDBContext()
        {
            //_strConn = "Data Source=127.0.0.1;Initial Catalog=StudyMVC;User ID=sa;password=jkl147258;";
        }
        public StudyMVCDBContext(DbContextOptions<StudyMVCDBContext> options) : base(options)
        {
        }
        public StudyMVCDBContext(string strConn)
        {
            this._strConn = strConn;
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }
        public virtual DbSet<StudyType> StudyType { get; set; }
        public virtual DbSet<Studyknowledge> Studyknowledge { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_strConn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region  角色和用户 角色和角色权限 多对多
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<RoleResouce>().HasKey(x => new { x.RoleId, x.ResourceId });
            #endregion
            #region  用户表和用户密码表外键设置  一对一
            modelBuilder.Entity<User>()
                .HasOne(x => x.UserPassword)
                .WithOne(x => x.User)
                .HasForeignKey<UserPassword>(x => x.UserId);
            #endregion
            #region  学习表和学习类型表外键设置  一对多
            modelBuilder.Entity<Studyknowledge>()
                .HasOne(x => x.StudyType)
                .WithMany(y => y.Studyknowledge)
                .HasForeignKey(x => x.StudyTypeId);
            #endregion

            List<User> users = new(); //初始用户拥有一切权限
            List<UserPassword> userPassword = new();//初始用户密码
            List<StudyType> studyTypes = new()
            {
                new StudyType() { StudyTypeId = 1, StudyTypeName = "前端" },
                new StudyType() { StudyTypeId = 2, StudyTypeName = "后端" },
                new StudyType() { StudyTypeId = 3, StudyTypeName = "数据库" }
            };
            List<Resource> resources = new()
            {
                //                ResourceId	ResourceName	ParentId	Path	Level	Icon	Sort	CreateTime	UpdateTime
                //                A3B47D09 - 8073 - 418A - BF71 - 040DFAB7EDFC    个人信息    7463DEDF - F007 - 429E-8471 - 252681F3C9BE / PersonalInfo / Index 1   el - icon - s - grid  0   NULL    NULL
                //1F4EDBC1 - 62C0 - 48BF - A93D - 0CF1A741ECEA    日志  7463DEDF - F007 - 429E-8471 - 252681F3C9BE / Journal / Index  1   el - icon - s - grid  2   NULL    NULL
                //7463DEDF - F007 - 429E-8471 - 252681F3C9BE    个人管理    NULL        0   el - icon - user - solid  0   NULL    NULL
                //F8EC7F0A - 1BFB - 44A6 - A0D5 - 397BDA61EF05    角色管理    23784655 - 41D7 - 4EBC - 9E57 - AEBA856978AF / Role / Index 1   el - icon - s - grid  1   2021 - 08 - 30 22:11:24.637 2021 - 08 - 30 22:11:24.637
                //23784655 - 41D7 - 4EBC - 9E57 - AEBA856978AF    系统管理 NULL        0   el - icon - s - tools 0   NULL NULL
                //7803799B - 2D02 - 4848 - AF39 - B26DB19F3288    权限管理    23784655 - 41D7 - 4EBC - 9E57 - AEBA856978AF / Permissions / index  1   el - icon - s - grid  2   2021 - 08 - 30 22:11:24.640 2021 - 08 - 30 22:11:24.640
                //F7F98D08 - 4778 - 45AA - A1D9 - B3DADAC9EAF8    学习数据    7463DEDF - F007 - 429E-8471 - 252681F3C9BE / Study / Studyknowledge   1   el - icon - s - grid  1   NULL NULL
                //0EDD2120 - 1744 - 41ED - 8D0F - E53FADC1571A    用户管理    23784655 - 41D7 - 4EBC - 9E57 - AEBA856978AF / UserManage / Index   1   el - icon - s - grid  0   2021 - 08 - 30 22:11:24.637 2021 - 08 - 30 22:11:24.637
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                },
                new Resource
                {
                    Icon = "",
                    Level = 0,
                    ParentId = Guid.Empty,
                    Path = "",
                    ResourceId = Guid.Empty,
                    ResourceName = "",
                    Sort = 0
                }

            }; //资源表初始值
            List<Role> roles = new()
            {
                new Role { RoleId = Guid.NewGuid(), RoleName = "", RoleDescribe = "" },
                new Role { RoleId = Guid.NewGuid(), RoleName = "", RoleDescribe = "" },
                new Role { RoleId = Guid.NewGuid(), RoleName = "", RoleDescribe = "" }
            };    //角色初始值
            List<UserRole> userRoles = new() { };   //给一个用户全部权限
            List<RoleResouce> roleResouces = new() { }; //不同角色对应的权限

            var userGuid = Guid.NewGuid();
            var userPasswordGuid = Guid.NewGuid();
            var emptyUser = new User()
            {
                Account = 1314520,
                Id = userGuid,
                Name = "小杰",
                Birthday = new DateTime(2001, 11, 18),
                Hobby = "Do Love",
            };
            var emptyUserPassword = new UserPassword()
            {
                UserPasswordId = userPasswordGuid,
                NewPassword = "123456".ToMD5(),
                UserId = userGuid
            };

            users.Add(emptyUser);
            userPassword.Add(emptyUserPassword);

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserPassword>().HasData(userPassword);
            modelBuilder.Entity<StudyType>().HasData(studyTypes);
            modelBuilder.Entity<Resource>().HasData(resources);
            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<UserRole>().HasData(userRoles);
            modelBuilder.Entity<RoleResouce>().HasData(roleResouces);

        }

    }
}
