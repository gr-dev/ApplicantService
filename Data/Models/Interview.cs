using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Interview
    {
        public int Id { get; set; }
        /// <summary>
        /// кому выдано (соискатель)
        /// </summary>
        public int ExecutorId { get; set; }

        public virtual Applicant Applicant { get; set; }

        /// <summary>
        /// Выдано (получено соискателем)
        /// </summary>
        public DateTime Received { get; set; }

        /// <summary>
        /// Проверяющий
        /// </summary>
        public int ExamenotorId { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public InterviewStatus Status { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public Rating? Rating { get; set; }

        /// <summary>
        /// Должность, на которую претендует
        /// </summary>
        public string PositionFor { get; set; }

        /// <summary>
        /// Задание
        /// </summary>
        public string Exercise { get; set; }

        /// <summary>
        /// кто проводил собеседование
        /// </summary>
        public int InterviewerId { get; set; }

        /// <summary>
        /// Срок выполнения
        /// </summary>
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime? DoneTime { get; set; }

    }

    public enum InterviewStatus
    {
        получено, сдано, оценено, просрочено
    }
    
    public enum Rating
    {
        ужасно, плохо, удовлетворительно, хорошо, отлично
    }
}
