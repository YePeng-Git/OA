using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using OA.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OA.DAL
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public class BaseRepository<T> where T : class
    {
        /// <summary>
        /// 获取的是当前线程内部的上下文实例，而且保证了线程内上下文唯一
        /// </summary>
        private readonly DbContext db = EFContextFactory.GetCurrentDbContext();


        #region  新增（返回是否成功）+ Add
        /// <summary>
        /// 新增（返回是否成功）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            //EF4.0的写法   添加实体
            //db.CreateObjectSet<T>().AddObject(entity);
            //EF5.0的写法
            db.Entry<T>(entity).State = EntityState.Added;

            //下面的写法统一
            return db.SaveChanges() > 0;
        }
        #endregion

        #region 新增（返回实体对象）+ AddEntity
        /// <summary>
        /// 新增（返回实体对象）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            //EF4.0的写法   添加实体
            //db.CreateObjectSet<T>().AddObject(entity);
            //EF5.0的写法
            db.Entry<T>(entity).State = EntityState.Added;

            //下面的写法统一
            db.SaveChanges();
            if (db.SaveChanges() > 0)
                return entity;
            else
                return null;
        }
        #endregion

        #region 修改（返回是否成功）+ Update
        /// <summary>
        /// 修改（返回是否成功）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //EF5.0的写法
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        #endregion

        #region 修改（返回实体对象）+ UpdateEntity
        /// <summary>
        /// 修改（返回实体对象）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T UpdateEntity(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //EF5.0的写法
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
                return entity;
            else
                return null;
        }
        #endregion

        #region 删除 （返回是否成功）+ Delete
        /// <summary>
        /// 删除 （返回是否成功）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
        #endregion

        #region 删除（返回删除对象）+ DeleteEntity
        /// <summary>
        /// 删除（返回删除对象）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T DeleteEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            if (db.SaveChanges() > 0)
                return entity;
            else
                return null;
        }
        #endregion

        #region 简单查询 DoSearch
        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <returns>返回一个实体类的IQueryable集合</returns>
        public IQueryable<T> DoSearch(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda).AsQueryable();
        }
        #endregion

        #region 分页功能 PageHelper
        /// <summary>
        /// 分页功能
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="SortName">根据那个字段进行排序</param>
        /// <param name="SortOrder">如何排序，根据倒叙还是升序</param>
        /// <returns>返回一个实体类型的IQueryable集合</returns>
        public IQueryable<T> PageHelper(int pageIndex, int pageSize, out int total,
                                            Expression<Func<T, bool>> whereLambda,
                                            string SortName,
                                            string SortOrder)
        {
            var list = db.Set<T>().Where<T>(whereLambda);//获取筛选后的所有记录

            total = list.Count();//得到总的条数

            list = PageSort<T>(list, SortName, SortOrder);

            list = list.Skip<T>((pageIndex - 1) * pageSize)//越过多少条
                       .Take<T>(pageIndex * pageSize);//取出多少条
            return list.AsQueryable();
        }


        public LambdaExpression GetLambdaExpression<T>(string propertyName)
        {
            //1.创建表达式参数（指定参数或变量的类型:p）  
            ParameterExpression param = Expression.Parameter(typeof(T));
            //2.构建表达式体(类型包含指定的属性:p.Name)  
            MemberExpression body = Expression.Property(param, propertyName);
            //3.根据参数和表达式体构造一个lambda表达式  
            return Expression.Lambda(body, param);
        }  

        #endregion

        /// <summary>
        /// 采用反射的方式 排序数据集合
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="sortName">排序字段</param>
        /// <param name="sortOrder">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> PageSort<T>(IQueryable<T> source, string sortName, string sortOrder)
        {
            string sort = string.Empty;
            if (sortOrder.ToUpper().Trim().Equals("ASC"))
            {
                sort = "OrderBy";
            }
            else if (sortOrder.ToUpper().Trim().Equals("DESC"))
            {
                sort = "OrderByDescending";
            }

            ParameterExpression param = Expression.Parameter(typeof(T), sortName);
            PropertyInfo pi = typeof(T).GetProperty(sortName);

            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sort, types, source.Expression, Expression.Lambda(Expression.Property(param, sortName), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }
    }
}
