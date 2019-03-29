
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Oiga.Technologies.Data.Entities.DTO
{
    public class UserDTO
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// constraseña
        /// </summary>
        public string UserPass { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// fecha de actualización
        /// </summary>
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}
