using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMS.Data.Entities
{
    public class Message : Entity
    {
        public string Nick { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
