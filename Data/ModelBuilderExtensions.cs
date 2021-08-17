using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WSMS.Data.Identity;
using WSMS.Data.Entities;

namespace WSMS.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdmin(this ModelBuilder builder)
        {
            string ADMIN_ROLEID = Guid.NewGuid().ToString();
            string ADMIN_USERID = Guid.NewGuid().ToString();

            var appUser = new ApplicationUser
            {
                Id = ADMIN_USERID,
                FullName = "Super User",
                Email = "sudo@local.com",
                UserName = "sudo",
                NormalizedUserName = "SUDO",
                NormalizedEmail = "SUDO@LOCAL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = hasher.HashPassword(appUser, "P@ss1234");

            builder.Entity<ApplicationUser>().HasData(appUser);

            builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            {
                new ApplicationRole {
                    Id = ADMIN_ROLEID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new ApplicationRole {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Member",
                    NormalizedName = "MEMBER"
                }
            });

            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                RoleId = ADMIN_ROLEID,
                UserId = ADMIN_USERID
            });
        }

    public static void SeedBooks(this ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(new List<Book>
            {
                new Book
                {
                    Id = 1,
                    BookNumber = 1,
                    Title = "Genesis",
                },
                new Book
                {
                    Id = 2,
                    BookNumber = 2,
                    Title = "Exodus",
                },
                new Book
                {
                    Id = 3,
                    BookNumber = 3,
                    Title = "Leviticus",
                },
                new Book
                {
                    Id = 4,
                    BookNumber = 4,
                    Title = "Numbers",
                },
                new Book
                {
                    Id = 5,
                    BookNumber = 5,
                    Title = "Deuteronomy",
                },
                new Book
                {
                    Id = 6,
                    BookNumber = 6,
                    Title = "Joshua",
                },
                new Book
                {
                    Id = 7,
                    BookNumber = 7,
                    Title = "Judges",
                },
                new Book
                {
                    Id = 8,
                    BookNumber = 8,
                    Title = "Ruth",
                },
                new Book
                {
                    Id = 9,
                    BookNumber = 9,
                    Title = "1 Samuel",
                },
                new Book
                {
                    Id = 10,
                    BookNumber = 10,
                    Title = "2 Samuel",
                },
                new Book
                {
                    Id = 11,
                    BookNumber = 11,
                    Title = "1 Kings",
                },
                new Book
                {
                    Id = 12,
                    BookNumber = 12,
                    Title = "2 Kings",
                },
                new Book
                {
                    Id = 13,
                    BookNumber = 13,
                    Title = "1 Chronicles",
                },
                new Book
                {
                    Id = 14,
                    BookNumber = 14,
                    Title = "2 Chronicles",
                },
                new Book
                {
                    Id = 15,
                    BookNumber = 15,
                    Title = "Ezra",
                },
                new Book
                {
                    Id = 16,
                    BookNumber = 16,
                    Title = "Nehemiah",
                },
                new Book
                {
                    Id = 17,
                    BookNumber = 17,
                    Title = "Esther",
                },
                new Book
                {
                    Id = 18,
                    BookNumber = 18,
                    Title = "Job",
                },
                new Book
                {
                    Id = 19,
                    BookNumber = 19,
                    Title = "Psalms",
                },
                new Book
                {
                    Id = 20,
                    BookNumber = 20,
                    Title = "Proverbs",
                },
                new Book
                {
                    Id = 21,
                    BookNumber = 21,
                    Title = "Ecclesiastes",
                },
                new Book
                {
                    Id = 22,
                    BookNumber = 22,
                    Title = "Song of Solomon",
                },
                new Book
                {
                    Id = 23,
                    BookNumber = 23,
                    Title = "Isaiah",
                },
                new Book
                {
                    Id = 24,
                    BookNumber = 24,
                    Title = "Jeremiah",
                },
                new Book
                {
                    Id = 25,
                    BookNumber = 25,
                    Title = "Lamentations",
                },
                new Book
                {
                    Id = 26,
                    BookNumber = 26,
                    Title = "Ezekiel",
                },
                new Book
                {
                    Id = 27,
                    BookNumber = 27,
                    Title = "Daniel",
                },
                new Book
                {
                    Id = 28,
                    BookNumber = 28,
                    Title = "Hosea",
                },
                new Book
                {
                    Id = 29,
                    BookNumber = 29,
                    Title = "Joel",
                },
                new Book
                {
                    Id = 30,
                    BookNumber = 30,
                    Title = "Amos",
                },
                new Book
                {
                    Id = 31,
                    BookNumber = 31,
                    Title = "Obadiah",
                },
                new Book
                {
                    Id = 32,
                    BookNumber = 32,
                    Title = "Jonah",
                },
                new Book
                {
                    Id = 33,
                    BookNumber = 33,
                    Title = "Micah",
                },
                new Book
                {
                    Id = 34,
                    BookNumber = 34,
                    Title = "Nahum",
                },
                new Book
                {
                    Id = 35,
                    BookNumber = 35,
                    Title = "Habakkuk",
                },
                new Book
                {
                    Id = 36,
                    BookNumber = 36,
                    Title = "Zephaniah",
                },
                new Book
                {
                    Id = 37,
                    BookNumber = 37,
                    Title = "Haggai",
                },
                new Book
                {
                    Id = 38,
                    BookNumber = 38,
                    Title = "Zechariah",
                },
                new Book
                {
                    Id = 39,
                    BookNumber = 39,
                    Title = "Malachi",
                },
                new Book
                {
                    Id = 40,
                    BookNumber = 40,
                    Title = "Tobit",
                },
                new Book
                {
                    Id = 41,
                    BookNumber = 41,
                    Title = "Esther (Greek)",
                },
                new Book
                {
                    Id = 42,
                    BookNumber = 42,
                    Title = "Wisdom of Solomon",
                },
                new Book
                {
                    Id = 43,
                    BookNumber = 43,
                    Title = "Sirach",
                },
                new Book
                {
                    Id = 44,
                    BookNumber = 44,
                    Title = "Baruch",
                },
                new Book
                {
                    Id = 45,
                    BookNumber = 45,
                    Title = "1 Maccabees",
                },
                new Book
                {
                    Id = 46,
                    BookNumber = 46,
                    Title = "2 Maccabees",
                },
                new Book
                {
                    Id = 47,
                    BookNumber = 47,
                    Title = "1 Esdras",
                },
                new Book
                {
                    Id = 48,
                    BookNumber = 48,
                    Title = "Prayer of Manasses",
                },
                new Book
                {
                    Id = 49,
                    BookNumber = 49,
                    Title = "Psalm 151",
                },
                new Book
                {
                    Id = 50,
                    BookNumber = 50,
                    Title = "3 Maccabees",
                },
                new Book
                {
                    Id = 51,
                    BookNumber = 51,
                    Title = "2 Esdras",
                },
                new Book
                {
                    Id = 52,
                    BookNumber = 52,
                    Title = "4 Maccabees",
                },
                new Book
                {
                    Id = 53,
                    BookNumber = 53,
                    Title = "Daniel (Greek)",
                },
                new Book
                {
                    Id = 54,
                    BookNumber = 54,
                    Title = "Matthew",
                },
                new Book
                {
                    Id = 55,
                    BookNumber = 55,
                    Title = "Mark",
                },
                new Book
                {
                    Id = 56,
                    BookNumber = 56,
                    Title = "Luke",
                },
                new Book
                {
                    Id = 57,
                    BookNumber = 57,
                    Title = "John",
                },
                new Book
                {
                    Id = 58,
                    BookNumber = 58,
                    Title = "Acts",
                },
                new Book
                {
                    Id = 59,
                    BookNumber = 59,
                    Title = "Romans",
                },
                new Book
                {
                    Id = 60,
                    BookNumber = 60,
                    Title = "1 Corinthians",
                },
                new Book
                {
                    Id = 61,
                    BookNumber = 61,
                    Title ="2 Corinthians",
                },
                new Book
                {
                    Id = 62,
                    BookNumber = 62,
                    Title = "Galatians",
                },
                new Book
                {
                    Id = 63,
                    BookNumber = 63,
                    Title = "Ephesians",
                },
                new Book
                {
                    Id = 64,
                    BookNumber = 64,
                    Title = "Philippians",
                },
                new Book
                {
                    Id = 65,
                    BookNumber = 65,
                    Title = "Colossians",
                },
                new Book
                {
                    Id = 66,
                    BookNumber = 66,
                    Title = "1 Thessalonians",
                },
                new Book
                {
                    Id = 67,
                    BookNumber = 67,
                    Title = "2 Thessalonians",
                },
                new Book
                {
                    Id = 68,
                    BookNumber = 68,
                    Title = "1 Timothy",
                },
                new Book
                {
                    Id = 69,
                    BookNumber = 69,
                    Title = "2 Timothy",
                },
                new Book
                {
                    Id = 70,
                    BookNumber = 70,
                    Title = "Titus",
                },
                new Book
                {
                    Id = 71,
                    BookNumber = 71,
                    Title = "Philemon",
                },
                new Book
                {
                    Id = 72,
                    BookNumber = 72,
                    Title = "Hebrews",
                },
                new Book
                {
                    Id = 73,
                    BookNumber = 73,
                    Title = "James",
                },
                new Book
                {
                    Id = 74,
                    BookNumber = 74,
                    Title = "1 Peter",
                },
                new Book
                {
                    Id = 75,
                    BookNumber = 75,
                    Title = "2 Peter",
                },
                new Book
                {
                    Id = 76,
                    BookNumber = 76,
                    Title = "1 John",
                },
                new Book
                {
                    Id = 77,
                    BookNumber = 77,
                    Title = "2 John",
                },
                new Book
                {
                    Id = 78,
                    BookNumber = 78,
                    Title = "3 John",
                },
                new Book
                {
                    Id = 79,
                    BookNumber = 79,
                    Title = "Jude",
                },
                new Book
                {
                    Id = 80,
                    BookNumber = 80,
                    Title = "Revelation",
                },
            });
        }
    }
}