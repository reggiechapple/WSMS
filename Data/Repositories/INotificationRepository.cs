using System.Collections.Generic;
using WSMS.Data.Entities;

namespace WSMS.Data.Repositories
{
    public interface INotificationRepository
    {
        List<UserNotification> GetUserNotifications(long userId);
        void Create(Notification notification, long channelId);
        void ReadNotification(long notificationId, long memberId);
    }
}