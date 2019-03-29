using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Technologies.Data.Entities.Entity
{
    public class User
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// constraseña
        /// </summary>
        public virtual string UserPass { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public virtual DateTime CreationDate { get; set; }

        /// <summary>
        /// fecha de actualización
        /// </summary>
        public virtual DateTime? UpdateDate { get; set; }
    }
}
