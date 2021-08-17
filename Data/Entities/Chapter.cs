using System.Collections.Generic;

namespace WSMS.Data.Entities
{
    public class Chapter : Entity
    {
        public int ChapterNumber { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }

        public ICollection<Verse> Verses { get; set; } = new List<Verse>();
    }
}