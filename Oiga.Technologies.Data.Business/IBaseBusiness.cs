
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Result.Base;

#endregion

namespace Oiga.Technologies.Data.Business
{
    public interface IBaseBusiness<T>
    {
        #region Queries

        Task<BusinessResult<List<T>>> GetAll(int quantity = 0);

        Task<BusinessResult<List<T>>> GetAllBy(Expression<Func<T, bool>> condition);

        Task<BusinessResult<T>> GetById(int id);

        Task<BusinessResult<T>> GetBy(Expression<Func<T, bool>> condition);

        #endregion

        #region Insert
        /// <summary>
        /// Metodo que agrerga un entidad de tipo {T}
        /// </summary>
        /// <param name="entity">Entidad de tipo {T}</param>
        /// <returns>Retorna la entidad de tipo {T} generada</returns>
        Task<BusinessResult<T>> CreateAsync(T entity);
        #endregion

        #region Edit
        /// <summary>
        /// Edita una entidad de tipo {T}
        /// </summary>
        /// <param name="entity">Entidad de tipo {T}</param>
        /// <returns>Retorno la entidad modificada de tipo {T}</returns>
        Task<BusinessResult<bool>> EditAsync(T entity);
        #endregion

        #region Delete

        /// <summary>
        /// Metodo para eliminar una entidad de tipo {T} por su identificador
        /// </summary>
        /// <param name="id">Identificador de la {T}</param>
        /// <returns>Retorna verdadero si se pudo eliminar, de lo contrario retorna falso></returns>
        Task<BusinessResult<bool>> Delete(int id);

        #endregion
    }
}
