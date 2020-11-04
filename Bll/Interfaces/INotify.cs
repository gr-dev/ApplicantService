using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface INotify
    {
        public Task NotifyAsync(User user, string message);
    }
}
