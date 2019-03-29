
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Result.Base;
using Oiga.Technologies.Data.Business.Interfaces;
using Oiga.Technologies.Data.Entities.DTO;
using Oiga.Technologies.Data.Model.Interfaces;
using Oiga.Technologies.Data.Model.Implementation;
using Oiga.Technologies.Module.Commons.Resources;
using Oiga.Technologies.Module.Commons.Exceptions;
using Oiga.Technologies.Module.Commons.Utilities;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using NHibernate.Exceptions;

#endregion

namespace Oiga.Technologies.Data.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        /// <summary>
        /// Instancia del modelo
        /// </summary>
        private IUserModel _iuserModel;

        public UserBusiness()
        {
            _iuserModel = new UserModel();
        }

        public UserBusiness(IUserModel userModel)
        {
            _iuserModel = userModel;
        }

        public async Task<BusinessResult<UserDTO>> CreateAsync(UserDTO entity)
        {
            try
            {

                if (!ValidatePassword(entity.UserPass))
                {
                    throw new UserException(General.InvalidPassword);
                }

                entity.CreationDate = DatetimeHelper.GetCurrentColombianTime();

                var resultOperation = await _iuserModel.CreateAsync(entity);
                return BusinessResult<UserDTO>.Success(resultOperation, General.OperationSucsess);
            }
            catch (UserException user)
            {
                return BusinessResult<UserDTO>.Issue(null, user.Message, user);
            }
            catch (GenericADOException ex)
            {
                var sql = ex.InnerException as SqlException;
                if (sql != null && sql.Number == 2627)
                {
                    // Here's where to handle the unique constraint violation
                    return BusinessResult<UserDTO>.Issue(null, General.UniqueUserName, sql);
                }
                else
                {
                    return BusinessResult<UserDTO>.Issue(null, General.OperationIssue, sql);

                }
            }
            catch (Exception ex)
            {
                return BusinessResult<UserDTO>.Issue(null, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<bool>> Delete(int id)
        {
            try
            {
                var resultOperation = await _iuserModel.Delete(id);
                return BusinessResult<bool>.Success(resultOperation, General.OperationSucsess);
            }
            catch (Exception ex)
            {
                return BusinessResult<bool>.Issue(false, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<bool>> EditAsync(UserDTO entity)
        {
            try
            {

                if (!ValidatePassword(entity.UserPass))
                {
                    throw new UserException(General.InvalidPassword);
                }

                entity.UpdateDate = DatetimeHelper.GetCurrentColombianTime();

                var resultOperation = await _iuserModel.EditAsync(entity);
                return BusinessResult<bool>.Success(resultOperation, General.OperationSucsess);
            }
            catch (UserException user)
            {
                return BusinessResult<bool>.Issue(false, user.Message, user);
            }
            catch (GenericADOException ex)
            {
                var sql = ex.InnerException as SqlException;
                if (sql != null && sql.Number == 2627)
                {
                    // Here's where to handle the unique constraint violation
                    return BusinessResult<bool>.Issue(false, General.UniqueUserName, sql);
                }
                else
                {
                    return BusinessResult<bool>.Issue(false, General.OperationIssue, sql);
                }
            }
            catch (Exception ex)
            {
                return BusinessResult<bool>.Issue(false, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<List<UserDTO>>> GetAll(int quantity = 0)
        {
            try
            {
                var resultOperation = await _iuserModel.GetAll(quantity);
                return BusinessResult<List<UserDTO>>.Success(resultOperation, General.OperationSucsess);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<UserDTO>>.Issue(null, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<List<UserDTO>>> GetAllBy(Expression<Func<UserDTO, bool>> condition)
        {
            try
            {
                var resultOperation = await _iuserModel.GetAllBy(condition);
                return BusinessResult<List<UserDTO>>.Success(resultOperation, General.OperationSucsess);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<UserDTO>>.Issue(null, General.OperationIssue, ex);
            }
        }

        public BusinessResult<List<UserDTO>> GetAllSync()
        {
            try
            {
                return BusinessResult<List<UserDTO>>.Success(_iuserModel.GetAllSync(), General.OperationSucsess);
            }
            catch (Exception ex)
            {

                return BusinessResult<List<UserDTO>>.Issue(null, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<UserDTO>> GetBy(Expression<Func<UserDTO, bool>> condition)
        {
            try
            {
                var resultOperation = await _iuserModel.GetBy(condition);
                return BusinessResult<UserDTO>.Success(resultOperation, General.OperationSucsess);
            }
            catch (Exception ex)
            {
                return BusinessResult<UserDTO>.Issue(null, General.OperationIssue, ex);
            }
        }

        public async Task<BusinessResult<UserDTO>> GetById(int id)
        {
            try
            {
                var resultOperation = await _iuserModel.GetById(id);
                return BusinessResult<UserDTO>.Success(resultOperation, General.OperationSucsess);
            }
            catch (Exception ex)
            {
                return BusinessResult<UserDTO>.Issue(null, General.OperationIssue, ex);
            }
        }

        #region Utilities

        private bool ValidatePassword(string password)
        {
            Regex rePassword = new Regex(General.ValidatePasswordExpressionRegular);
            if (rePassword.Match(password).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
