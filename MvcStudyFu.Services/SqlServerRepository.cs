using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MvcStudyFu.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcStudyFu.EFCore.SQLSever;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.Common;

namespace MvcStudyFu.Services
{
    public class SqlServerRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        public SqlServerRepository(StudyMVCDBContext generalDbContext, IConfiguration configuration)
            : base(generalDbContext)
        {
            this._configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:Write"];
          
        }
        #region 插入数据

        /// <summary>
        /// 使用Bulk批量插入数据（适合大数据量，速度非常快）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">数据</param>
        public override void BulkInsert<T>(List<T> entities)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string tableName = string.Empty;
                var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
                if (tableAttribute != null)
                    tableName = ((TableAttribute)tableAttribute).Name;
                else
                    tableName = typeof(T).Name;

                SqlBulkCopy sqlBC = new SqlBulkCopy(conn)
                {
                    BatchSize = 100000,
                    BulkCopyTimeout = 0,
                    DestinationTableName = tableName
                };
                using (sqlBC)
                {
                    sqlBC.WriteToServer(entities.ToDataTable());
                }
            }
        }

        public override DataTable GetDataTableWithSql(string sql)
        {
            return GetDataTableWithSql(sql);
        }

        public override DataTable GetDataTableWithSql(string sql, List<DbParameter> spList = null)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandType = CommandType.Text;
                if (spList.ToArray() != null)
                {
                    da.SelectCommand.Parameters.AddRange(spList.ToArray());
                }
                da.Fill(dt);
            }
            return dt;
        }
        #endregion
    }
}
