using Microsoft.Data.SqlClient;
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
using static LinqToDB.SqlQuery.SqlPredicate;
using MvcStudyFu.Common.ConvertTpye;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace MvcStudyFu.Services
{
    public abstract class BaseService : IBaseService, IDisposable
    {
        public StudyMVCDBContext _DBContext = null;

        public IDBContextFactory _contextFactory = null;
        public BaseService(IDBContextFactory contextFactory)
        {
            this._contextFactory = ConvertExtension.IsTypeNull<IDBContextFactory>
                  (this._contextFactory, contextFactory);
            this._DBContext = ConvertExtension.IsTypeNull<StudyMVCDBContext>
             (_DBContext, this._contextFactory?.CreateDbContext());
        }
        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            _DBContext.SaveChanges();
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async virtual Task CommitAsync()
        {
            await _DBContext.SaveChangesAsync();
        }
        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public virtual void Delete<T>(Guid id) where T : class
        {
            T t = _DBContext.Set<T>().Find(id);
            if (t == null) throw new Exception("不存在这个，不用删");
            _DBContext.Set<T>().Remove(t);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public virtual void Delete<T>(IEnumerable<T> tList) where T : class
        {
            if (tList.Count() < 0) throw new Exception("不存在这个，不用删");
            _DBContext.Set<T>().RemoveRange(tList);
        }
        /// <summary>
        /// 删除异步版
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task DeleteAsync<T>(Guid id) where T : class
        {
            T t = await _DBContext.Set<T>().FindAsync(id);
            if (t == null) throw new Exception("不存在这个，不用删");
            _DBContext.Set<T>().Remove(t);
        }
        /// <summary>
        /// 批量删除异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public async Task DeleteAsync<T>(IEnumerable<T> tList) where T : class
        {
            if (tList.Count() < 0) throw new Exception("不存在这个，不用删");
            await Task.Run(() => _DBContext.Set<T>().RemoveRange(tList));
        }

        public void Dispose()
        {
            if (_DBContext != null) _DBContext.Dispose();
        }
        public async Task DisposeAyscn()
        {
            if (_DBContext != null) await _DBContext.DisposeAsync();
        }
        /// <summary>
        /// 增删改 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        public virtual void Excute<T>
            (string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增删改 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        public virtual Task ExcuteAsync<T>
            (string sql, SqlParameter[] parameter) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 带DBparam查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual IQueryable<T> ExcuteQuery<T>
            (string sql, SqlParameter[] parameter) where T : class
        {
            var TIQueryable = _DBContext.Set<T>()
                .FromSqlRaw(sql, parameter);
            return TIQueryable;
        }
        /// <summary>
        ///字符串拼接查询 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual Task<IQueryable<T>> ExcuteQueryAsync<T>
          (FormattableString sql) where T : class
        {
            Func<IQueryable<T>> func = () =>
                _DBContext.Set<T>()
                     .FromSqlInterpolated(sql);
            Task<IQueryable<T>> TIQueryable = Task<IQueryable<T>>.Run(func);
            Task.WaitAll(TIQueryable);
            return TIQueryable;

        }
        /// <summary>
        /// 字符串拼接查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual IQueryable<T> ExcuteQuery<T>
          (FormattableString sql) where T : class
        {
            var TIQueryable = _DBContext.Set<T>()
                  .FromSqlInterpolated(sql);
            return TIQueryable;
        }
        /// <summary>
        /// 带DBparam查询 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual Task<IQueryable<T>> ExcuteQueryAsync<T>
            (string sql, SqlParameter[] parameter) where T : class
        {
            Func<IQueryable<T>> func = () =>
            _DBContext.Set<T>()
               .FromSqlRaw(sql, parameter);
            Task<IQueryable<T>> TIQueryable = Task<IQueryable<T>>.Run(func);
            Task.WaitAll(TIQueryable);
            return TIQueryable;
        }

        public virtual T Find<T>(int id) where T : class
        {
            return _DBContext.Set<T>().Find(id);
        }

        public virtual T Find<T>(Guid? id) where T : class
        {
            return _DBContext.Set<T>().Find(id);
        }

        public async virtual Task<T> FindAsync<T>(Guid? id) where T : class
        {
            return await _DBContext.Set<T>().FindAsync(id);
        }

        public async virtual Task<T> FindAsync<T>
            (int id) where T : class
        {
            return await _DBContext.Set<T>().FindAsync(id);
        }

        public virtual T Insert<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Insert<T>
            (IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> InsertAsync<T>
            (T t) where T : class
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
