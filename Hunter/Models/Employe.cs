using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    /// <summary>
    /// сотрудник
    /// </summary>
    public class Employe
    {
        public int Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public string Position { get; set; }

        
    }
}
