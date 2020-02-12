using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using Microsoft.Win32;
using System.Configuration;


namespace DAL
{
    public abstract class RepositoryBase<T> where T : class
    {

        internal SyndromeDBEntities _dataContext;
        internal DbSet<T> _dbset;
        public RepositoryBase(SyndromeDBEntities context)
        {
            try
            {
                this._dataContext = context;
                this._dataContext.Configuration.LazyLoadingEnabled = true;
                //this._dataContext.Database.Connection.ConnectionString = "";              
                this._dbset = context.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void setExectionTimeout(int seconds)
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this._dataContext).ObjectContext.CommandTimeout = seconds;
        }

        public virtual List<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = _dbset;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Add(T entity)
        {
            try
            {
                _dbset.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                _dbset.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            try
            {
                IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                    _dbset.Remove(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T GetById(long id)
        {
            try
            {
                return _dbset.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T GetById(int id)
        {
            try
            {
                return _dbset.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T GetById(string id)
        {
            try
            {
                return _dbset.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _dbset.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

           // return null;
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbset.Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbset.Where(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbset.Where(where).FirstOrDefault<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T GetLast<TOrderKey>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderKey>> order, bool descending = true)
        {
            try
            {
                if(descending)
                    return _dbset.Where(where).OrderByDescending(order).FirstOrDefault<T>();
                return _dbset.Where(where).OrderBy(order).FirstOrDefault<T>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbset.Where(where).FirstOrDefault<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbset.Any(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
