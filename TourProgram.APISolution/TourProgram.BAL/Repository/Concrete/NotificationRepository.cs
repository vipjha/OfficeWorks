

using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Notification;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MailSettingsModel _mailSettings;
        public NotificationRepository(IOptions<MailSettingsModel> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<ResponeModel> SendMail(MailRequestModel mailRequest)
        {
            ResponeModel responeModel = new ResponeModel();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.SenderName);
            email.To.Add(MailboxAddress.Parse(mailRequest.EmailToId));
            email.Subject = mailRequest.EmailSubject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, MimeKit.ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.EmailBody;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Message = "OTP code send successfully.";
            return responeModel;
        }
    }
}
