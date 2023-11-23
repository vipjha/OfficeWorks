
using HealthClaim.Model.Dtos.Notification;
using HealthClaim.Model.Dtos.Response;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface INotification
    {
        public Task<ResponeModel> SendMail(MailRequestModel mailRequest);
    }
}
