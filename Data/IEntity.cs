using System;

namespace WSMS.Data
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}