using Bll;
using Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NotifyWorker
{
    class Program
    {
        /// <summary>
        /// Под этой штукой подразумевается циклически запускаемая задача, проверяющая статусы выполнения заданий и высылающая уведомления.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var conf = builder.Build();
            Console.WriteLine("начал выполнение задания");
            MakeWork(GetApplicationContext(conf), GetNotifier(conf));
        }

        static INotify GetNotifier(IConfiguration configuration)
        {
            return new MailNotifier(configuration.GetValue<string>("smtpServer"));
        }
        static ApplicationContext GetApplicationContext(IConfiguration configuration)
        {
            return new MyApplicationContext(configuration.GetConnectionString("DefaultConnection"));
        }

        static void MakeWork(ApplicationContext context, INotify notify)
        {
            var interviews = context.GetInterviews();
            var now = DateTime.Now;
            interviews.Where(x => x.DeadLine < now & x.DoneTime == null & x.Rating == null).ToList();
            foreach (var inteview in interviews)
            {
                Console.WriteLine($"интервью {inteview.Id} просрочено. Уведомляю сотрудника отдела кадров и соискателя");
                inteview.Rating = Data.Models.Rating.ужасно;
                //TODO: не оптимизировано. Убрать эту строку
                var user = context.GetApplicant(inteview.ExecutorId);
                notify.NotifyAsync(user, "Истекло время выполнения задания. Задание оценено на 'ужасно'");
                //TODO: не оптимизировано. Убрать эту строку
                var interviewer = context.GetApplicant(inteview.InterviewerId);
                //Уведомление сотрудника отдела кадров. 
                notify.NotifyAsync(interviewer, $"интервью {inteview.Id} просрочено. Выставлена оценка 'ужасно'");
            }
        }
    }
}
