using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    /// <summary>
    /// класс, представляющий модель для оценки выполненного задания. Закладываю то, что можно было расширить комментарием, например
    /// </summary>
    public class RateInterviewModel
    {
        public int InterviewId { get; set; }
        public int Rating { get; set; }
    }
}
