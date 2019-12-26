using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EmailSender
{
    public  interface IMessageService
    {
        Task SendEmail(
            string FromName,
            string FromEmailAddress,
            string ToName,
            string ToEmailAddress,
            string Subject,
            string Message,
            params Attachment[] attachments);

    }
}
