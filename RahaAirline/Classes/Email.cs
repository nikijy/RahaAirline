﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace RahaAirline
{
    public class Email
    {
        public static void Send(string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("nikitmb2@gmail.com", "آژانس هواپیمایی رها");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("nikitmb2@gmail.com", "n13781127");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
