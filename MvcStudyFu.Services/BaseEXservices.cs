using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcStudyFu.Common;
using MvcStudyFu.Common.Enum;
using MvcStudyFu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services
{
    public class BaseEXservices : IBaseEXService
    {
        protected IDbContextFactory _ContextFactory = null;
        protected DbContext Context { get; set; }
        public BaseEXservices(IDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }
        public void Commit()
        {
            this.Context.SaveChanges();
        }
        public async void CommitAsync()
        {
           await this.Context.SaveChangesAsync();
        }

        public void Delete<T>(Guid id) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }

        public void Excute<T>(string sql, SqlParameter[] parameter) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameter) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public T Insert<T>(T t) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funWhere) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOderby, bool isAsc = true) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public IQueryable<T> Set<T>() where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Read);
            throw new NotImplementedException();
        }

        public void Update<T>(T t) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            throw new NotImplementedException();
        }
    }
}
