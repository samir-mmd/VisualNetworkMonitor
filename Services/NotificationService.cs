using GalaSoft.MvvmLight.Messaging;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using VNM2020.Messaging;
using VNM2020.Models;

namespace VNM2020.Services
{
    public class NotificationService
    {
        public async static void SendMail(string subject, string body,string mailTo)
        {
            try
            {
                if (!IsValidEmail(mailTo))
                {
                    mailTo = GlobalSettings.Instance.mailTo;
                }      

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(GlobalSettings.Instance.mailFrom, GlobalSettings.Instance.mailFrom));
                message.To.Add(new MailboxAddress(mailTo, mailTo));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var emailClient = new SmtpClient())
                {
                    await emailClient.ConnectAsync(GlobalSettings.Instance.mailServer, GlobalSettings.Instance.mailPort, SecureSocketOptions.Auto);
                    await emailClient.AuthenticateAsync(GlobalSettings.Instance.mailFrom, GlobalSettings.Instance.mailPass);

                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    await emailClient.SendAsync(message);
                    NotificationService.AddtoLog("Done", "Mail Engine", $"Mail {subject} sent to {mailTo}");

                    await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                NotificationService.AddtoLog("Exception", "Mail Engine", e.Message);
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (!String.IsNullOrWhiteSpace(email))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch (Exception e)
                {
                    NotificationService.AddtoLog("Exception", "Mail Engine", e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void AddtoLog(string status, string source, string body)
        {
            if (!GlobalSettings.Instance.Closing)
            {
                var logmessage = new LogMessage(DateTime.Now, status, source, body);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    Core.Instance.mainLog.Insert(0, logmessage);
                    using (StreamWriter sw = File.AppendText($@"Logs\Log {DateTime.Now.ToString("dd-MM-yy")}.txt"))
                    {
                        sw.WriteLine($"{logmessage.date.ToString("dd.MM.yy HH:mm:ss.fff")} {status} {source} {body}");
                    }
                }));
                Messenger.Default.Send(new UIMessage { PropName = "MainLogView" });
            }
            

        }
    }
}
