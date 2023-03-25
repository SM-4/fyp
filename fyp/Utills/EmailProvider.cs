using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace fyp.Utills
{
    public static class EmailProvider
    {
        public static void Email(string receiverEmail,string emailSubject,string mailBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(ConfigurationManager.AppSettings["Email"]);
                message.To.Add(new MailAddress(receiverEmail));
                message.Subject = emailSubject;

                message.IsBodyHtml = true; //to make message body as html
                message.Body = mailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
        //public static void SendEmail(string receiverEmail, int code)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();
        //        SmtpClient smtp = new SmtpClient();
        //        message.From = new MailAddress(ConfigurationManager.AppSettings["Email"]);
        //        message.To.Add(new MailAddress(receiverEmail));
        //        message.Subject = "test";

        //        message.IsBodyHtml = true; //to make message body as html
        //        message.Body = "Your code for forget password is" + code;
        //        smtp.Port = 587;
        //        smtp.Host = "smtp.gmail.com"; //for gmail host
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.Send(message);
        //    }
        //    catch (Exception) { }
        //}

    }
}