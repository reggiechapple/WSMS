using System.Collections.Generic;
using WSMS.Data.Entities;

namespace WSMS.Data.Identity
{
    public class Member : Profile
    {
        public ICollection<UserNotification> Notifications { get; set; } = new List<UserNotification>();
        public ICollection<ChatUser> Chats { get; set; } = new List<ChatUser>();
    }
}