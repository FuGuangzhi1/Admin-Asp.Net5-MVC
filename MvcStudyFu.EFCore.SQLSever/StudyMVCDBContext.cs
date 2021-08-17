using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.Common;
using MvcStudyFu.EFCore.SQLSever.DomainModel;
using System;
using System.Collections.Generic;


namespace MvcStudyFu.EFCore.SQLSever
{
    //Add-Migration InitialCreate数据迁移
    //Update-Database CodeFirst
    public class StudyMVCDBContext : DbContext
    {
        private readonly string _strConn;
        public StudyMVCDBContext(DbContextOptions<StudyMVCDBContext> options) :base(options)
        { }
        public StudyMVCDBContext() 
        {
            //_strConn = "Data Source=127.0.0.1;Initial Catalog=StudyMVC;User ID=sa;password=jkl147258";
        }
        public StudyMVCDBContext(string strConn) 
        {
            this._strConn = strConn;
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_strConn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.UserPassword)
                .WithOne(x => x.User)
                .HasForeignKey<UserPassword>(x => x.UserId);
            var userGuid = Guid.NewGuid();
            var userPasswordGuid = Guid.NewGuid();
            var emptyUser = new User()
            {
                Account = 1314520,
                Id = userGuid,
                Name = "小杰",
                CheckCode = ""
                ,UserPasswordId= userPasswordGuid
            };
            modelBuilder.Entity<User>().HasData(new List<User>() {
             emptyUser
            });
            modelBuilder.Entity<UserPassword>().HasData(new List<UserPassword>() {
            new UserPassword(){
                UserPasswordId=userPasswordGuid,
                NewPassword ="123456".ToMD5(),
                UserId=userGuid
            }
            });
        }
    }
}
