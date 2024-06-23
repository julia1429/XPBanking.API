using System.Net;
using XPBanking.API.Services.Dto;
using XPBanking.API.Services.Interface;
using SendGrid.Helpers.Mail;
using SendGrid;
using MimeKit;
using Org.BouncyCastle.Utilities.Net;
using MailKit.Net.Smtp;
using System.Globalization;

namespace XPBanking.API.Services
{
    public class SendEmailService : ISendEmailService
    {
        private const string SendGridApiKey = ""; 
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "juliasouza1429@gmail.com";
        private readonly string _smtpPassword = "testetesteteste";

        public async Task EnviarEmailParaId(UserTransaction user)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Julia", "juliasouza1429@hotmail.com"));
                message.To.Add(new MailboxAddress("", user.email));
                message.Subject = "Investmento Perto do Vencimento";
                string body = $"Seu investimento: {user.AssetName} está próximo a data de vencimento";

                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using var client = new SmtpClient();
                client.Connect("smtp-mail.outlook.com", 587, false);
                client.Authenticate("juliasouza1429@hotmail.com", "juthomaspattz15");
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail para o ID {user.UserId}: {ex.Message}");
            }
        }
    }
}
