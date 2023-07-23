using QMS.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Shared.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Welcome to Worinium QMS";
        }
    }
}
