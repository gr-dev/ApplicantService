using Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public interface INotify
    {
        public Task NotifyAsync(User user, string message);
    }

    public class MailNotifier : INotify
    {
        string Parameter { get; set; }

        public MailNotifier(string server)
        {
            this.Parameter = server;
        }
        public async Task NotifyAsync(User user, string message)
        {
            await Task.Factory.StartNew(() => Console.WriteLine($"сообщение '{message}' отправлено пользоватлю {user.Name} через {this.Parameter}"));

        }
    }
}
