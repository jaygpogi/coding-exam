using Azure.Communication.Email;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;

namespace CodingExam
{
    public class Common
    { 
        public string? GetParticipant(string? participantId)
        {
            if (string.IsNullOrWhiteSpace(participantId))
            {
                return string.Empty;
            }

            if (Debugger.IsAttached)
            {
                return "Jay Pogi";
            }

            return Environment.GetEnvironmentVariable(participantId);
        }

        public async Task SendEmail(string subject, string content, string? attachmentContent = null)
        {
            if (Debugger.IsAttached)
            {
                return;
            }

            var emailClient = new EmailClient(Environment.GetEnvironmentVariable("EMAIL_CONNECTION_STRING"));
            var senderAddress = Environment.GetEnvironmentVariable("EMAIL_SENDER_ADDRESS");
            var recipient = Environment.GetEnvironmentVariable("EMAIL_RECIPIENT");
            var emailContent = new EmailContent(subject) { Html = content };
            var emailMessage = new EmailMessage(senderAddress, recipient, emailContent);
            if (!string.IsNullOrWhiteSpace(attachmentContent))
            {
                emailMessage.Attachments.Add(new EmailAttachment("code.txt", "txt", BinaryData.FromString(attachmentContent)));
            }
            await emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);
        }

        public DateTime ToSingaporeTime(DateTime dateTime)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, timeZone);
        }
    }
}
