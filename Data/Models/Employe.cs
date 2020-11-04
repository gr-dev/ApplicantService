using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// сотрудник
    /// </summary>
    public class Employe :User
    {

        /// <summary>
        /// должность
        /// </summary>
        public string Position { get; set; }

        
    }
}
