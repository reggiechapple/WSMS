namespace WSMS.Data.Entities
{
    public class Verse : Entity
    {
        public int VerseNumber { get; set; }
        public string Text { get; set; }
        
        public long ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}