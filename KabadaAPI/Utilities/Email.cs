using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace KabadaAPI.DataSource.Utilities
{
    public static class Email
    {
        ////private static readonly string baseURL = "http://localhost:3000/";
        //private static readonly string baseURL = "http://kabada.ba.lv/";

        public static bool isValid(string emailAddress)
        {
            return (new EmailAddressAttribute()).IsValid(emailAddress);
        }

        public static void SendOnRegistrationConfirmation(string userEmail, Kmail alternative=null)
        {
            string messageText = $"Hi,<br /><br />";
            messageText += $"You have successfully created an account.<br />";
            messageText += $"Thank you for registering to KABADA system.<br /><br />";
            messageText += $"We hope you will enjoy exploring it.<br />";
            messageText += $"KABADA Team";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailAccount.UserName, "KABADA"),
                Subject = "Welcome",
                Body = messageText,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(userEmail);

            if(alternative!=null){
              alternative.send(mailMessage);
              return;
              }

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailAccount.UserName, EmailAccount.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);

        }

        public static void SendPasswordResetLink(string userEmail, string passwordString, Kmail alternative=null)
        {
            string messageText = $"Hi,<br /><br />";
            messageText += $"<a href=\"{alternative.Opt.baseURL}set-password?requestId={passwordString}\">Password reset link</a><br /><br />";
            messageText += $"KABADA Team";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailAccount.UserName, "KABADA"),
                Subject = "Reset password",
                Body = messageText,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(userEmail);

            if(alternative!=null){
              alternative.send(mailMessage);
              return;
              }

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailAccount.UserName, EmailAccount.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
            
        }

        public static void SendOnPasswordChange(string userEmail, Kmail alternative=null)
        {
            string messageText = $"Hi,<br /><br />";
            messageText += $"New password have been set.<br /><br />";
            messageText += $"KABADA Team";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailAccount.UserName, "KABADA"),
                Subject = "Update password",
                Body = messageText,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(userEmail);

            if(alternative!=null){
              alternative.send(mailMessage);
              return;
              }

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailAccount.UserName, EmailAccount.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
        }


        //public static void SendEmailChange(string userEmail)
        //{
        //    string messageText = $"Hi,<br /><br />";
        //    messageText += $"Password reset link:{baseURL}set-password?requestId={userEmail}<br /><br />";
        //    messageText += $"KABADA Team";

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress(EmailAccount.UserName, "KABADA"),
        //        Subject = "Update password",
        //        Body = messageText,
        //        IsBodyHtml = true,
        //    };
        //    mailMessage.To.Add(userEmail);
        //    SendGmail(mailMessage);
        //}

        //private static void SendGmail(MailMessage mailMessage){
        //    var smtpClient = new SmtpClient
        //    {  Host="smtp.gmail.com",
        //        Port = 587,
        //        Credentials = new NetworkCredential(EmailAccount.UserName, EmailAccount.Password),
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        EnableSsl = true,
        //        UseDefaultCredentials = false
        //    };

        //    smtpClient.Send(mailMessage);
        //  }
    }
}
