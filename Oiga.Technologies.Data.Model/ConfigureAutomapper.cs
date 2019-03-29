
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Oiga.Technologies.Data.Entities.DTO;
using Oiga.Technologies.Data.Entities.Entity;

#endregion

namespace Oiga.Technologies.Data.Model
{
    public class ConfigureAutomapper: Profile
    {
        public ConfigureAutomapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }

        /// <summary>
        /// Init automapper
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ConfigureAutomapper>();
            });
        }
    }
}
