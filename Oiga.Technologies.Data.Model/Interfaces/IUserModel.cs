
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oiga.Technologies.Data.Entities.DTO;

#endregion

namespace Oiga.Technologies.Data.Model.Interfaces
{
    public interface IUserModel: IBaseModel<UserDTO>
    {
        List<UserDTO> GetAllSync();
    }
}
