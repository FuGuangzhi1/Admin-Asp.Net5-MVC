using Microsoft.Data.SqlClient;
using MvcStudyFu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface
{
    public interface IBaseEXService
    {
        T Find<T>(int id) where T : class;
        IQueryable<T> Set<T>() where T : class;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funWhere) where T : class;
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class;
        T Insert<T>(T t) where T : class;
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;
        void Update<T>(T t) where T : class;
        void Update<T>(IEnumerable<T> tList) where T : class;
        void Delete<T>(Guid id) where T : class;
        void Delete<T>(IEnumerable<T> tList) where T : class;
        void Commit();
        IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameter) where T : class;
        void Excute<T>(string sql, SqlParameter[] parameter) where T : class;
    }
}
