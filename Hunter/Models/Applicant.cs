using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    /// <summary>
    /// Соискатель
    /// </summary>
    public class Applicant
    {
        public int Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        
        public string Phone { get; set; }
    }
}
