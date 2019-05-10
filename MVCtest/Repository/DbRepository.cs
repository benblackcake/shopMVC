using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCtest.Repository
{
    public class DbRepository<T>where T:class{

        private DBModel _context;
        
        protected DBModel context { get { return _context;} }

        public DbRepository(DBModel context)
        {
            if (context == null) throw new ArgumentException();
            _context = context;

        }

        public void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }


        #region 新增 GetAll 多載
        //public IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> keySelector)
        //{
        //   return  _context.Set<T>().OrderBy(keySelector);
        //}

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        #endregion
    }
}