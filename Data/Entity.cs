using System;

namespace WSMS.Data
{
    public class Entity : IEntity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}