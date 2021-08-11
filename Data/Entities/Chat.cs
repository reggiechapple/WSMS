using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMS.Data.Entities
{
    public class Chat : Entity
    {

        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<ChatUser> Users { get; set; } = new List<ChatUser>();
        public ChatType Type { get; set; }
    }

    public enum ChatType
    {
        Room,
        Private
    }

    
}
