using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.IDAL;

namespace OA.DAL
{
    public partial class DbSession : IDbSession
    {
        /// <summary>
        /// 代表：当前应用程序跟数据库的会话内所有的实体的变化，更新会数据库
        /// </summary>
        /// <returns>返回受影响的行数</returns>
        public int SaveChanges()
        {
            //调用EF上下文的SaveChanges方法
            return DAL.DbSessionFactory.GetCurrentDbSession().SaveChanges();
        }

        /// <summary>
        /// 执行Sql脚本的方法
        /// </summary>
        /// <param name="strSql">执行的SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回受影响的行数</returns>
        public int ExcuteSql(string strSql, System.Data.Common.DbParameter[] parameters)
        {
            //Ef4.0的执行方法 ObjectContext
            //封装一个执行SQl脚本的代码
            //return DAL.EFContextFactory.GetCurrentDbContext().ExecuteFunction(strSql, parameters);
            throw new NotImplementedException();
        }
    }
}
