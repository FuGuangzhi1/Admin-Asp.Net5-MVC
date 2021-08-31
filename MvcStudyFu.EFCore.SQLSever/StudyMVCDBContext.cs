using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.Common;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Generic;


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
            modelBuilder.Entity<UserRole>().HasKey(x=>new { x.RoleId,x.UserId });
            modelBuilder.Entity<RoleResouce>().HasKey(x=>new { x.RoleId,x.ResourceId });
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
        }

    }
}
