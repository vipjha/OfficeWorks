

using Microsoft.AspNetCore.Http;

namespace TourProgram.Model.Dtos.Notification
{
    public class MailRequestModel
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
