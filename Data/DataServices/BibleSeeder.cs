using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WSMS.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WSMS.Data.DataServices
{
    public class BibleSeeder : IBibleSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BibleSeeder(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void LoadBookChapters(string title, int chapterCount)
        {
            Console.WriteLine("Test 1");
            List<string> titles = this.BookTitles();

            if (titles.Contains(title))
            {
                Book book = _context.Books.Include(b => b.Chapters).SingleOrDefault(b => b.Title == title);
                Console.WriteLine("Test 2");

                if (!book.Chapters.Any())
                {
                    Console.WriteLine("Test 3");
                    if (chapterCount > 0)
                    {
                        for (int i = 0; i < chapterCount; i++)
                        {
                            _context.Chapters.Add(new Chapter
                            {
                                ChapterNumber = i + 1,
                                BookId = book.Id
                            });
                        }
                        _context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Book has chapters.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
                
            }
        }

        public void VerseImporter(string bookTitle, int chapterNumber)
        {
            // get book
            Book book = _context.Books.SingleOrDefault(b => b.Title == bookTitle);
            Chapter chapter = _context.Chapters.Include(c => c.Verses).SingleOrDefault(c => c.BookId == book.Id && c.ChapterNumber == chapterNumber);

            if (!chapter.Verses.Any())
            {
                // get json data
                string wwwroot = _environment.WebRootPath + Path.DirectorySeparatorChar + "bible" + Path.DirectorySeparatorChar + bookTitle.ToLower() + ".json";

                using (StreamReader r = new StreamReader(wwwroot))
                {
                    string jsonstring = r.ReadToEnd();
                    var jsonArray = JArray.Parse(jsonstring);

                    //iterate all values in array
                    foreach(var jToken in jsonArray)
                    {
                        if ((int) jToken["chapterNumber"] == chapterNumber)
                        {
                            _context.Verses.Add(new Verse
                            {
                                VerseNumber = (int) jToken["VerseNumber"],
                                Text = jToken["Text"].ToString(),
                                ChapterId = chapter.Id
                            });
                        }
                    }
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Chapter has verses.");
            }
            
        }

        public void SeedBook(string bookTitle, int chapters)
        {
            this.LoadBookChapters(bookTitle, chapters);
            for (int i = 0; i < chapters; i++)
            {
                this.VerseImporter(bookTitle, i+1);
            }
        }

        public List<string> BookTitles()
        {
            return new List<string>()
            {
                "Genesis",
                "Exodus",
                "Leviticus",
                "Numbers",
                "Deuteronomy",
                "Joshua",
                "Judges",
                "Ruth",
                "1 Samuel",
                "2 Samuel",
                "1 Kings",
                "2 Kings",
                "1 Chronicles",
                "2 Chronicles",
                "Ezra",
                "Nehemiah",
                "Esther",
                "Job",
                "Psalms",
                "Proverbs",
                "Ecclesiastes",
                "Song of Solomon",
                "Isaiah",
                "Jeremiah",
                "Lamentations",
                "Ezekiel",
                "Daniel",
                "Hosea",
                "Joel",
                "Amos",
                "Obadiah",
                "Jonah",
                "Micah",
                "Nahum",
                "Habakkuk",
                "Zephaniah",
                "Haggai",
                "Zechariah",
                "Malachi",
                "Tobit",
                "Esther (Greek)",
                "Wisdom of Solomon",
                "Sirach",
                "Baruch",
                "1 Maccabees",
                "2 Maccabees",
                "1 Esdras",
                "Prayer of Manasses",
                "Psalm 151",
                "3 Maccabees",
                "2 Esdras",
                "4 Maccabees",
                "Daniel (Greek)",
                "Matthew",
                "Mark",
                "Luke",
                "John",
                "Acts",
                "Romans",
                "1 Corinthians",
                "2 Corinthians",
                "Galatians",
                "Ephesians",
                "Philippians",
                "Colossians",
                "1 Thessalonians",
                "2 Thessalonians",
                "1 Timothy",
                "2 Timothy",
                "Titus",
                "Philemon",
                "Hebrews",
                "James",
                "1 Peter",
                "2 Peter",
                "1 John",
                "2 John",
                "3 John",
                "Jude",
                "Revelation",
            };
        }
    }
}