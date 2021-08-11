using System;
using WSMS.Data.Identity;

namespace WSMS.Data.Entities
{
    public class ChatUser
    {
        public long UserId { get; set; }
        public Member User { get; set; }

        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        
        public ChatRole Role { get; set; }
    }
}
