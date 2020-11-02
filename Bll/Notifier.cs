using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public abstract class Notifier
    {
        public abstract Task NotifySubscribersAsync(Message message);
    }

    public abstract class Message
    {
        public string Subject { get; set; }
        public object Payload{ get; set; }
    }
}
