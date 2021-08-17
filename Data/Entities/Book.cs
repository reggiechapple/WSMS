using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSMS.Data.Entities
{
    public class Book : Entity
    {
        [Required]
        public int BookNumber { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }
}