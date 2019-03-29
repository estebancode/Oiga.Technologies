
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oiga.Technologies.Data.Entities.DTO;
using Business.Result.Base;

#endregion

namespace Oiga.Technologies.Data.Business.Interfaces
{
    public interface IUserBusiness: IBaseBusiness<UserDTO>
    {
        BusinessResult<List<UserDTO>> GetAllSync();
    }
}
