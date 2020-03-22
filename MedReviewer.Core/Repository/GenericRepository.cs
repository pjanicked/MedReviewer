using MedReviewer.Core.DatabaseContext;
using MedReviewer.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Generic Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Added entity</returns>
        public TEntity Add(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    using (var DbContext = new DataContext())
                    {
                        DbContext.Set<TEntity>().Add(entity);
                        if (DbContext.SaveChanges() > 0)
                        {
                            return entity;
                        }
                        else
                        {
                            throw new Exception(String.Format("{0} not saved in DB", typeof(TEntity).Name));
                        }
                    }
                }
                else
                {
                    throw new Exception("Parameter is null");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("{0} not saved in DB", typeof(TEntity).Name));
            }
        }

        /// <summary>
        /// Generic delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>deleted entity</returns>
        public TEntity Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    using (var DbContext = new DataContext())
                    {
                        DbContext.Entry(entity).State = System.Data.EntityState.Deleted;
                        if (DbContext.SaveChanges() > 0)
                        {
                            return entity;
                        }
                        else
                        {
                            throw new Exception(String.Format("{0} not deleted in DB", typeof(TEntity).Name));
                        }
                    }
                }
                else
                {
                    throw new Exception("Parameter is null");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("{0} not deleted in DB", typeof(TEntity).Name));
            }
        }

        /// <summary>
        /// Generic Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    using (var DbContext = new DataContext())
                    {
                        DbContext.Set<TEntity>().AddOrUpdate(entity);
                        if (DbContext.SaveChanges() > 0)
                        {
                            return entity;
                        }
                        else
                        {
                            throw new Exception(String.Format("{0} not updated in DB", typeof(TEntity).Name));
                        }
                    }
                }
                else
                {
                    throw new Exception("Parameter is null");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("{0} not updated in DB", typeof(TEntity).Name));
            }
        }

        /// <summary>
        /// Get All data of a entity
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetSelectList()
        {
            try
            {
                using (var DbContext = new DataContext())
                {
                    var objList = DbContext.Set<TEntity>().ToList();
                    return objList;
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        /// <summary>
        /// Check object duplicacy
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool CheckDuplicate(Expression<Func<TEntity, bool>> where)
        {
            bool _isDuplicate = false;
            object obj = null;
            try
            {
                if(where != null)
                {
                    using (var DbContext = new DataContext())
                    {
                        obj = DbContext.Set<TEntity>().Where(where).FirstOrDefault();
                        if(obj == null)
                        {
                            _isDuplicate = false;
                        }
                        else
                        {
                            _isDuplicate = true;
                        }
                    }
                }
                else
                {
                    throw new Exception("parameter is null");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _isDuplicate;
        }
    }
}
