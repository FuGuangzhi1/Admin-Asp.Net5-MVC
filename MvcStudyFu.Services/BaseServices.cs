using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MvcStudyFu.Common.ConvertTpye;
using Z.EntityFramework.Plus;

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
        public bool Commit()
        {
            bool result = true;
            try
            {
                result = _DBContext.SaveChanges() > 0;
            }
            catch (DbUpdateException)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async virtual Task<(bool, string)> CommitAsync()
        {
            (bool, string) result = (false, "操作成功");
            try
            {
                result.Item1 = await _DBContext.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException db)
            {
                result.Item1 = false;
                result.Item2 = db.Message;
            }
            catch (Exception ex) { result.Item1 = false; result.Item2 = ex.Message; }
            return result;
        }
        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public virtual void Delete<T>(Guid id) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            if (!tList.Any()) throw new Exception("不存在这个，不用删");
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            if (tList.Count() < 0) throw new Exception("不存在这个，不用删");
            await Task.Run(() => _DBContext.Set<T>().RemoveRange(tList));
        }

        public void Dispose()
        {
            if (_DBContext != null) _DBContext.Dispose();
        }
        public async Task DisposeAsync()
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
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
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            Func<IQueryable<T>> func = () =>
            _DBContext.Set<T>()
               .FromSqlRaw(sql, parameter);
            Task<IQueryable<T>> TIQueryable = Task<IQueryable<T>>.Run(func);
            Task.WaitAll(TIQueryable);
            return TIQueryable;
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public virtual T Find<T>(int id) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return _DBContext.Set<T>().Find(id);
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public virtual T Find<T>(Guid? id) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return _DBContext.Set<T>().Find(id);
        }
        /// <summary>
        /// 根据主键查询实体 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public async virtual Task<T> FindAsync<T>(Guid? id) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return await _DBContext.Set<T>().FindAsync(id);
        }
        /// <summary>
        /// 根据主键查询实体 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public async virtual Task<T> FindAsync<T>
            (int id) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return await _DBContext.Set<T>().FindAsync(id);
        }

        public virtual void Insert<T>(T t) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            _DBContext.Set<T>().Add(t);
        }

        public virtual void Insert<T>
            (IEnumerable<T> tList) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            _DBContext.Set<T>().AddRange(tList);
        }

        public async virtual Task InsertAsync<T>
            (T t) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            await _DBContext.Set<T>().AddAsync(t);
        }
        /// <summary>
        /// 批量 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public async Task InsertAsync<T>(IEnumerable<T> tList) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            await _DBContext.Set<T>().AddRangeAsync(tList);
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funWhere"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Query<T>(Expression<Func<T, bool>> funWhere) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return _DBContext.Set<T>().Where(funWhere);
        }
        /// <summary>
        /// 条件查询 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funWhere"></param>
        /// <returns></returns>
        public async virtual Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> funWhere) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return await Task.Run(() => _DBContext.Set<T>().Where(funWhere).AsTracking());
        }
        /// <summary>
        /// 查询单实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> Set<T>() where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return _DBContext.Set<T>();
        }
        /// <summary>
        /// 查询单实体集合 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public async virtual Task<IQueryable<T>> SetAsync<T>() where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            return await Task.Run(() => _DBContext.Set<T>());
        }
        /// <summary>
        ///  修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public virtual void Update<T>(T t) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            _DBContext.Set<T>().Update(t);
        }
        /// <summary>
        /// 批量 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public virtual void Update<T>(IEnumerable<T> tList) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            _DBContext.Set<T>().UpdateRange(tList);
        }
        /// <summary>
        /// 修改异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public async virtual Task UpdateAsync<T>(T t) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            await Task.Run(() => _DBContext.Set<T>().Update(t));
        }
        /// <summary>
        ///批量 修改异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public async virtual Task UpdateAsync<T>(IEnumerable<T> tList) where T : class
        {
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Write);
            await Task.Run(() => _DBContext.Set<T>().UpdateRange(tList));
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby) where T : class
        {
            PageResult<T> PageResult = new();
            if (pageSize == 0) return PageResult;
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            int offset = (pageIndex - 1) * pageSize; //当前页面
            var data = _DBContext.Set<T>();
            if (data != null && data.Any())
            {
                var datawhere = data.Where(funWhere);
                if (datawhere != null && datawhere.Any())
                {
                    var datapage = datawhere.OrderBy(funcOderby).Skip(offset).Take(pageSize);
                    PageResult.Rows = datapage.ToList();
                }
            }
            PageResult.Total = _DBContext.Set<T>().Count();
            return PageResult;
        }

        public async Task<PageResult<T>> QueryPageAsync<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby) where T : class
        {
            PageResult<T> PageResult = new();
            if (pageSize == 0) return PageResult;
            this._DBContext = this._contextFactory?.CreateDbContext(ReadWriteEnum.Read);
            int offset = (pageIndex - 1) * pageSize; //当前页面
            var data = _DBContext.Set<T>();
            if (data != null && data.Any())
            {
                var datawhere = data.Where(funWhere);
                if (datawhere != null && datawhere.Any())
                {
                    var datapage = datawhere.OrderBy(funcOderby).Skip(offset).Take(pageSize);
                    PageResult.Rows = await datapage.ToListAsync();
                }
            }
            PageResult.Total = await _DBContext.Set<T>().CountAsync();
            return PageResult;
        }

        public async Task<PageResult<T>> QueryPageAsync<T, S>(IQueryable<T> tList, Expression<Func<T, bool>> funWhere, Expression<Func<T, bool>> funWhere1, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby) where T : class
        {
            PageResult<T> PageResult = new();
            if (pageSize == 0) return PageResult;
            int offset = (pageIndex - 1) * pageSize; //当前页面
            var data = tList;
            if (data != null && data.Any())
            {
                var datawhere = data.Where(funWhere).Where(funWhere1);
                if (datawhere != null && datawhere.Any())
                {
                    var datapage = datawhere.OrderBy(funcOderby).Skip(offset).Take(pageSize);
                    PageResult.Rows = await datapage.ToListAsync();
                }
            }
            PageResult.Total = await tList.CountAsync();
            return PageResult;
        }

        
    }
}
