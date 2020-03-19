using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.InterfaceRepository
{
    /// <summary>
    /// generic interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        IList<TEntity> GetSelectList();
    }
}
