
using TourProgram.Model.Dtos.Notification;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Interface
{
    public interface INotificationRepository
    {
        public Task<ResponeModel> SendMail(MailRequestModel mailRequest);
    }
}
