using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common.Enum;
using MvcStudyFu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services
{
    public class BaseService : IBaseService, IDisposable
    {
        protected IDbContextFactory _ContextFactory = null;
        protected DbContext Context { get; set; }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="context"></param>
        public BaseService(IDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }
        /// <summary>
        /// 主库  即可以读取也可以增删改；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="readWriteEnum"></param>
        /// <returns></returns>
        public T Find<T>(int id, ReadWriteEnum readWriteEnum = ReadWriteEnum.Read) where T : class
        {
            //ReadWriteEnum.Read;
            //确定链接---从库
            Context = _ContextFactory.CreateDbContext(readWriteEnum);
            return this.Context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            //ReadWriteEnum.Read;
            //确定链接---主库
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            this.Context.Set<T>().Add(t);
            this.Commit();//写在这里  就不需要单独commit  不写就需要 
            return t;
        }
        public void Delete<T>(int Id) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            Context = _ContextFactory.CreateDbContext(ReadWriteEnum.Write);
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}
