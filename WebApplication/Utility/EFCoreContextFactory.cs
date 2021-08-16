using MvcStudyFu.EFCore.SQLSever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStudyFu.Common.Enum;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Interface;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WebApplication.Utility
{
    public class EFCoreContextFactory : IDbContextFactory
    {
        private static IConfiguration _configuration;
        private static DBConnectionOption _dBConnectionOption;
        public EFCoreContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static StudyMVCDBContext context = null;

        public StudyMVCDBContext CreateDbContext(ReadWriteEnum writeOrRead)
        {
            if (_configuration.GetSection("ConnectionStrings") == null) 
            {
                throw new Exception("请设置配置文件");
            }
            _dBConnectionOption = new DBConnectionOption()
            {
                MainConnectionString = _configuration["ConnectionStrings:Write"],
                SlaveConnectionStringList = new List<string> {
                    _configuration["ConnectionStrings:Read:0"],
                    _configuration["ConnectionStrings:Read:1"], }
            };
            switch (writeOrRead)
            {
                case ReadWriteEnum.Write:
                    context = new StudyMVCDBContext(_dBConnectionOption.MainConnectionString);
                    break;
                //主库连接 
                case ReadWriteEnum.Read:
                    context = new StudyMVCDBContext(GetReadConnect());
                    //从库连接
                    break;
                default:
                    break;
            }
            return context;

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
