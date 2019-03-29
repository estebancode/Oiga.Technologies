
#region Usings

using Oiga.Technologies.Data.Business.Implementation;
using Oiga.Technologies.Data.Business.Interfaces;
using Oiga.Technologies.Data.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Result.Base;

#endregion

namespace Oiga.Technologies.Web.Controllers
{
    public class UserController : ApiController
    {
        private IUserBusiness userBusiness { get { return new UserBusiness(); } }


        [HttpGet]
        [Route("api/User/GetAll")]
        public async Task<BusinessResult<List<UserDTO>>> Get()
        {
            var response = await userBusiness.GetAll();
            return response;
        }

        [HttpPost]
        [Route("api/User")]
        public async Task<BusinessResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            var response = await userBusiness.CreateAsync(userDTO);
            return response;
        }

        [HttpPut]
        [Route("api/User/{id}")]
        public async Task<BusinessResult<bool>> Put([FromUri]int id,[FromBody] UserDTO userDTO)
        {
            var response = await userBusiness.EditAsync(userDTO);
            return response;
        }


        [HttpDelete]
        [Route("api/User/{id}")]
        public async Task<BusinessResult<bool>> Delete([FromUri]int id)
        {
            var response = await userBusiness.Delete(id);
            return response;
        }


    }
}
