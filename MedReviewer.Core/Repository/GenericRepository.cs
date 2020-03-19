using MedReviewer.Core.DatabaseContext;
using MedReviewer.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
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
    }
}
