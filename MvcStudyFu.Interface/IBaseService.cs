using Microsoft.Data.SqlClient;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface
{
    public interface IBaseService
    {
        #region 查询
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;

        T Find<T>(Guid? id) where T : class;

        IQueryable<T> Set<T>() where T : class;

        IQueryable<T> Query<T>(Expression<Func<T, bool>> funWhere) where T : class;

        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class;


        IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameter) where T : class;

        Task<T> FindAsync<T>(Guid? id) where T : class;
        Task<T> FindAsync<T>(int id) where T : class;
        Task<IQueryable<T>> SetAsync<T>() where T : class;
        Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> funWhere) where T : class;
        Task<PageResult<T>> QueryPageAsync<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class;
        Task<IQueryable<T>> ExcuteQueryAsync<T>(string sql, SqlParameter[] parameter) where T : class;
        #endregion

        #region 新增
        T Insert<T>(T t) where T : class;

        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        Task<T> InsertAsync<T>(T t) where T : class;
        Task<IEnumerable<T>> InsertAsync<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region 修改
        void Update<T>(T t) where T : class;

        void Update<T>(IEnumerable<T> tList) where T : class;

        Task UpdateAsync<T>(T t) where T : class;
        Task UpdateAsync<T>(IEnumerable<T> tList) where T : class;

        #endregion
        
        #region 删除（删除前要查询）
        void Delete<T>(Guid id) where T : class;
        void Delete<T>(IEnumerable<T> tList) where T : class;

        Task DeleteAsync<T>(Guid id) where T : class;
        Task DeleteAsync<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Sql增删改
        void Excute<T>(string sql, SqlParameter[] parameter) where T : class;

        Task ExcuteAsync<T>(string sql, SqlParameter[] parameter) where T : class;
        #endregion
       
        #region 提交
        void Commit();
        Task CommitAsync();
        #endregion
    }
}
