using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.Common;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Concurrent;
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
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<LogRecord> LogRecord { get; set; }

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
            #region 用户与日志记录  一对多
            modelBuilder.Entity<LogRecord>()
               .HasOne(x => x.User)
               .WithMany(y => y.LogRecord)
               .HasForeignKey(x => x.UserId);
            #endregion

            ConcurrentDictionary<string, object> Guidvalues = Basicvalues.GetList(Basicvalues.GetGuid());

            modelBuilder.Entity<User>().HasData((List<User>)Guidvalues["users"]);
            modelBuilder.Entity<UserPassword>().HasData((List<UserPassword>)Guidvalues["userPasswords"]);
            modelBuilder.Entity<StudyType>().HasData((List<StudyType>)Guidvalues["studyTypes"]);
            modelBuilder.Entity<Resource>().HasData((List<Resource>)Guidvalues["resources"]);
            modelBuilder.Entity<Role>().HasData((List<Role>)Guidvalues["roles"]);
            modelBuilder.Entity<UserRole>().HasData((List<UserRole>)Guidvalues["userRoles"]);
            modelBuilder.Entity<RoleResouce>().HasData((List<RoleResouce>)Guidvalues["roleResouces"]);
        }

    }
}
