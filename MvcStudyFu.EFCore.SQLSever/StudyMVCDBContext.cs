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
        private readonly string _strConn;
        public StudyMVCDBContext()
        {
            _strConn = "Data Source=127.0.0.1;Initial Catalog=StudyMVC;User ID=sa;password=jkl147258";
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_strConn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region  用户表和用户密码表外键设置  一对一
            modelBuilder.Entity<User>()
                .HasOne(x => x.UserPassword)
                .WithOne(x => x.User)
                .HasForeignKey<UserPassword>(x => x.UserId);
            #endregion
            #region  学习表和学习类型表外键设置  一对多
            modelBuilder.Entity<Studyknowledge>()
                .HasOne(x => x.StudyType)
                .WithMany(y=>y.Studyknowledge)
                .HasForeignKey(x => x.StudyTypeId);
            #endregion

            List<User> users = new();
            List<UserPassword> userPassword = new();
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
