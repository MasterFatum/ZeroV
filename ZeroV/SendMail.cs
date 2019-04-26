using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ZeroV
{
    class SendEmail
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        

        public SendEmail(string emailFrom, string emailTo, string subject, string body)
        {
            EmailFrom = emailFrom;
            EmailTo = emailTo;
            Subject = subject;
            Body = body;
        }

        public void Send()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(EmailFrom);

            // кому отправляем
            MailAddress to = new MailAddress(EmailTo);

            // создаем объект сообщения
            MailMessage message = new MailMessage(from, to);

            // тема письма
            message.Subject = $": {Subject}";

            // текст письма
            message.Body = Body;

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("mail.fckrasnodar.ru", 25);

            // логин и пароль
            smtp.Credentials = new NetworkCredential("books@fckrasnodar.ru", "M212f3FAfib6j");
            smtp.Send(message);
        }
    }
}
