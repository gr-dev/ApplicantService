using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public abstract class Notifier
    {
        public abstract Task NotifyUserAsync(Message message, int userId);
    }


    public abstract class Message
    {
        public  string Title { get; set; }
        public  string Body { get; set; }
    }

    public class ConcreteMessage :Message
    {
        public ConcreteMessage(string title, string body)
        {
            this.Title = "Заголовко: " + title;
            this.Body = "тело: " + body;
        }
    }

    public class MailNotifier : Notifier
    {
        public async override Task NotifyUserAsync(Message message, int userId)
        {
            await Task.Factory.StartNew(() => Console.WriteLine($"сообщение {message.Title} отправлено пользоватлю {userId}"));
        }
    }
}
