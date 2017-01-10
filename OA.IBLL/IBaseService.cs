using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public interface IBaseService<T> where T : class ,new()
    {
        /// <summary>
        /// 实现对数据库的添加功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        bool Add(T entity);


        /// <summary>
        /// 实现对数据库的添加功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        T AddEntity(T entity);


        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        bool Update(T entity);


        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        T UpdateEntity(T entity);


        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        bool Delete(T entity);


        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        T DeleteEntity(T entity);


        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns>返回实体类的IQueryable集合</returns>
        IQueryable<T> DoSearch(Expression<Func<T, bool>> whereLimdba);


        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="SortName">根据那个字段进行排序</param>
        /// <param name="SortOrder">如何排序，根据倒叙还是升序</param>
        /// <returns>返回实体类的IQueryable集合</returns>
        IQueryable<T> PageHelper(int pageIndex, int pageSize, out int total,
                                     Expression<Func<T, bool>> whereLambda,
                                     string SortName,
                                     string SortOrder);

    }
}
