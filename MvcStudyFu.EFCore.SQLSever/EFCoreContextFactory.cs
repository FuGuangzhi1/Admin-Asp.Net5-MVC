using MvcStudyFu.EFCore.SQLSever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using StudyMVCFu.Model;
using MvcStudyFu.Common.ConvertTpye;

namespace MvcStudyFu.EFCore.SQLSever
{
    public class EFCoreContextFactory : IDBContextFactory
    {
        private readonly IConfiguration _configuration=null;
        private static DBConnectionOption _dBConnectionOption=null;
        private static StudyMVCDBContext _context = null;
        public EFCoreContextFactory(IConfiguration configuration)
        {
            if (this._configuration==null)
            this._configuration = configuration;
            if (_configuration["ConnectionStrings:Write"]==null)
            {
                throw new Exception("请设置配置文件");
            }
            if (_dBConnectionOption == null)
            {
                _dBConnectionOption = new DBConnectionOption()
                {
                    MainConnectionString = _configuration["ConnectionStrings:Write"],
                    SlaveConnectionStringList = new List<string> {
                    _configuration["ConnectionStrings:Read:0"],
                    _configuration["ConnectionStrings:Read:1"], }
                };
            }
        }
        public  StudyMVCDBContext CreateDbContext()
        {
            return new StudyMVCDBContext(_dBConnectionOption.MainConnectionString);
        }
        public StudyMVCDBContext CreateDbContext(ReadWriteEnum writeOrRead)
        {
            var whetherToSeparateReadingAndWriting = _configuration.GetSection("WhetherToSeparateReadingAndWriting");
            if (!whetherToSeparateReadingAndWriting.Exists())
            {
                if (whetherToSeparateReadingAndWriting.ToBool())
                {
                return new StudyMVCDBContext(_dBConnectionOption.MainConnectionString);
                }
            }
            try
            {
                switch (writeOrRead)
                {
                    case ReadWriteEnum.Write:
                        _context = new StudyMVCDBContext(_dBConnectionOption.MainConnectionString);
                        break;
                    //主库连接 
                    case ReadWriteEnum.Read:
                        _context = new StudyMVCDBContext(GetReadConnect());
                        //从库连接
                        break;
                    default:
                        break;
                }
            }
            catch (OutOfMemoryException)  //用 new 分配内存失败
            {
                return new StudyMVCDBContext(_dBConnectionOption.MainConnectionString);
            }
            catch (Exception)
            {
                throw new Exception("请配置数据库或者打开数据库代理");
            }
            return _context;
        }

        //1,当前请求数量
        private static int _currentRequestCount = 0;
        private static string GetReadConnect()
        {
            //定义一个轮询策略
            //根据请求量来取模
            int currentIndex = _currentRequestCount % _dBConnectionOption.SlaveConnectionStringList.Count;
            _currentRequestCount++;
            return _dBConnectionOption.SlaveConnectionStringList[currentIndex];

            //定义一个随机策略
            // int i = new Random().Next(0, strConns.Count);
            // return strConns[i];

        }
    }
}
