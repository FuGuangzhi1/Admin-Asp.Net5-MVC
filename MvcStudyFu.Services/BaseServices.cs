﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services
{
    public abstract class BaseService : IBaseService, IDisposable
    {
        public StudyMVCDBContext _DBContext;

        public IDbContextFactory _contextFactory;

        public BaseService(IDbContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
            this._DBContext = this._contextFactory.CreateDbContext();
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public virtual Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual void Delete<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_DBContext != null) _DBContext.Dispose();
        }
        public async Task DisposeAyscn()
        {
            if (_DBContext != null) await _DBContext.DisposeAsync();
        }
        public virtual void Excute<T>(string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task ExcuteAsync<T>(string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> ExcuteQueryAsync<T>(string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual T Find<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual T Find<T>(Guid? id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> FindAsync<T>(Guid? id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> FindAsync<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual T Insert<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> InsertAsync<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> InsertAsync<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Query<T>(Expression<Func<T, bool>> funWhere) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> funWhere) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<PageResult<T>> QueryPageAsync<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> SetAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public virtual void Update<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual void Update<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }
        PageResult<T> IBaseService.QueryPage<T, S>
        (Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc)
        {
            throw new NotImplementedException();
        }

        Task<PageResult<T>> IBaseService.QueryPageAsync<T, S>
            (Expression<Func<T, bool>> funWhere,
            int pageSize, int pageIndex,
            Expression<Func<T, S>> funcOderby,
            bool isAsc)
        {
            throw new NotImplementedException();
        }
    }
}