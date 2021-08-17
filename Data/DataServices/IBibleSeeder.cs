using System.Collections.Generic;
using WSMS.Data.Entities;

namespace WSMS.Data.DataServices
{
    public interface IBibleSeeder
    {
        void LoadBookChapters(string title, int chapterCount);
        void VerseImporter(string bookTitle, int chapterNumber);
        List<string> BookTitles();
        void SeedBook(string bookTitle, int chapters);
    }
}