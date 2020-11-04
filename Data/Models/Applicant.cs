using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{

    /// <summary>
    /// Соискатель
    /// </summary>
    public class Applicant : User
    {
        /// <summary>
        /// Телефон
        /// </summary>
        
        public string Phone { get; set; }
        public virtual List<Interview> Interviews { get; set; }
    }
}
