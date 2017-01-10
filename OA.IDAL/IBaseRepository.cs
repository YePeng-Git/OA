using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    /*
    .NET支持的类型参数约束
        where T : struct                   T必须是一个结构类型
        where T : class                    T必须是一个类（class）类型
        where T : new()                    T必须要有一个无参构造函数
        where T : NameOfBaseClass          T必须继承名为NameOfBaseClass的类
        where T : NameOfInterface          T必须实现名为NameOfInterface的接口
    */
    public interface IBaseRepository<T> where T : class,new()
    {
        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T entity);
        T AddEntity(T entity);

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);
        T UpdateEntity(T entity);


        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);
        T DeleteEntity(T entity);

        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> DoSearch(Expression<Func<T, bool>> whereLambda);


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
        /// <returns></returns>
        IQueryable<T> PageHelper(int pageIndex, int pageSize, out int total,
                                    Expression<Func<T, bool>> whereLambda,
                                     string SortName,
                                     string SortOrder);
    }
}
