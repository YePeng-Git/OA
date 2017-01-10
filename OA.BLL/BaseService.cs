using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using OA.IDAL;
using System.Linq.Expressions;

namespace OA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        /// <summary>
        /// 当前仓储
        /// </summary>
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        /// <summary>
        /// DbSession的存放，为了职责单一的原则，将获取线程内唯一实例的DbSession的逻辑放到工厂里面去了
        /// </summary>
        public IDbSession _DbSession = DbSessionFactory.GetCurrentDbSession();

        /// <summary>
        /// 基类的构造函数
        /// </summary>
        public BaseService()
        {
            SetCurrentRepository();  //构造函数里面去调用了，此设置当前仓储的抽象方法
        }

        /// <summary>
        /// 子类必须实现
        /// </summary>
        public abstract void SetCurrentRepository();


        /// <summary>
        /// 实现对数据库的添加功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        public bool Add(T entity)
        {
            //调用T对应的仓储来做添加工作
            var result = CurrentRepository.Add(entity);
            _DbSession.SaveChanges();
            return result;
        }

        /// <summary>
        /// 实现对数据库的添加功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        public T AddEntity(T entity)
        {
            //调用T对应的仓储来做添加工作
            var AddEntity = CurrentRepository.AddEntity(entity);
            _DbSession.SaveChanges();
            return AddEntity;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        public bool Update(T entity)
        {
            //调用T对应的仓储来做添加工作
            var result = CurrentRepository.Update(entity);
            _DbSession.SaveChanges();
            return result;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        public T UpdateEntity(T entity)
        {
            //调用T对应的仓储来做添加工作
            var UpdateEntity = CurrentRepository.UpdateEntity(entity);
            _DbSession.SaveChanges();
            return UpdateEntity;
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行结果</returns>
        public bool Delete(T entity)
        {
            //调用T对应的仓储来做添加工作
            var result = CurrentRepository.Delete(entity);
            _DbSession.SaveChanges();
            return result;
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回实体结果</returns>
        public T DeleteEntity(T entity)
        {
            //调用T对应的仓储来做添加工作
            var DeleteEntity = CurrentRepository.DeleteEntity(entity);
            _DbSession.SaveChanges();
            return DeleteEntity;
        }


        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns>返回实体类的IQueryable集合</returns>
        public IQueryable<T> DoSearch(Expression<Func<T, bool>> whereLimdba)
        {
            return CurrentRepository.DoSearch(whereLimdba);
        }


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
        public IQueryable<T> PageHelper(int pageIndex, int pageSize, out int total,
                                        Expression<Func<T, bool>> whereLambda,
                                        string SortName,
                                        string SortOrder)
        {
            return CurrentRepository.PageHelper(pageIndex, pageSize, out total, whereLambda, SortName, SortOrder);

        }


        public int SaveChange()
        {
            return _DbSession.SaveChanges();
        }
    }
}
