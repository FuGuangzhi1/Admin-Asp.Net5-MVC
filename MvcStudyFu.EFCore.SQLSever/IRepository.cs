using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.EFCore.SQLSever
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    { 
        #region 查找数据
        long Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool isNoTracking);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking);


        Task<TEntity> GetAsync(TKey id);

        IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> predicate, bool isNoTracking);
        Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, string ordering, bool isNoTracking);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, string ordering, bool isNoTracking);

        #endregion

        #region 插入数据
        bool Insert(TEntity entity, bool isSaveChange);
        Task<bool> InsertAsync(TEntity entity, bool isSaveChange);
        bool Insert(List<TEntity> entitys, bool isSaveChange = true);
        Task<bool> InsertAsync(List<TEntity> entitys, bool isSaveChange);
        #endregion

        #region 删除(删除之前需要查询)
        bool Delete(TEntity entity, bool isSaveChange);
        bool Delete(List<TEntity> entitys, bool isSaveChange);
        Task<bool> DeleteAsync(TEntity entity, bool isSaveChange);
        Task<bool> DeleteAsync(List<TEntity> entitys, bool isSaveChange = true);
        #endregion

        #region 修改数据
        bool Update(TEntity entity, bool isSaveChange, List<string> updatePropertyList);
        Task<bool> UpdateAsync(TEntity entity, bool isSaveChange, List<string> updatePropertyList);
        bool Update(List<TEntity> entitys, bool isSaveChange);
        Task<bool> UpdateAsync(List<TEntity> entitys, bool isSaveChange);
        #endregion

        #region 执行Sql语句
        void BulkInsert<T>(List<T> entities);
        int ExecuteSql(string sql);
        Task<int> ExecuteSqlAsync(string sql);
        int ExecuteSql(string sql, List<DbParameter> spList);
        Task<int> ExecuteSqlAsync(string sql, List<DbParameter> spList);
        DataTable GetDataTableWithSql(string sql);

        DataTable GetDataTableWithSql(string sql, List<DbParameter> spList);



        #endregion
    }
}