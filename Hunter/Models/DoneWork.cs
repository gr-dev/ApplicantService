using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    /// <summary>
    /// Олицетворяет выполненную работу от соискатель
    /// </summary>
    public class DoneWork
    {
        public string Exersice { get; set; }
        public int InterviewId { get; set; }
    }
}
