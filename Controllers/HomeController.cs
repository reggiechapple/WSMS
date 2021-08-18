using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WSMS.Data;
using WSMS.Data.DataServices;
using WSMS.Data.Entities;
using WSMS.Models;

namespace WSMS.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IBibleSeeder _seeder;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IBibleSeeder seeder)
        {
            _logger = logger;
            _context = context;
            _seeder = seeder;
        }

        [HttpGet("~/")]
        public IActionResult Index()
        {
            var member = _context.Members.SingleOrDefault(m => m.IdentityId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var chats = _context.Chats
                .Include(x => x.Users)
                .Where(u => !u.Users.Any(x => x.UserId == member.Id))
                .ToList();

            return View(chats);
        }

        [AllowAnonymous]
        [HttpGet("/[action]")]
        public IActionResult Seed()
        {
            //_seeder.SeedBook("Exodus", 40);
            return View();
        }

        [HttpGet("/[action]")]
        public IActionResult Find()
        {
            var member = _context.Members
                .Include(m => m.Identity)
                .SingleOrDefault(m => m.IdentityId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var users = _context.Members
                .Include(m => m.Identity)
                .Where(x => x.Id != member.Id)
                .ToList();

            return View(users);
        }

        [HttpGet("/[action]/{id}")]
        public IActionResult Chat(long id)
        {
            var chat = _context.Chats
                .Include(m => m.Messages)
                .FirstOrDefault(x => x.Id == id);
           
            return View(chat);
        }

        public async Task<IActionResult> CreateMessage(long chatId, string content)
        {
            var message = new Message
            {
                ChatId = chatId,
                Content = content,
                Nick = User.Identity.Name,
                Timestamp = DateTime.Now
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("Chat", new { id = chatId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };

            var member = _context.Members.Include(m => m.Identity).SingleOrDefault(m => m.IdentityId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            chat.Users.Add(new ChatUser
            {
                UserId = member.Id,
                Role = ChatRole.Admin
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Private()
        {
            var member = _context.Members
                .Include(m => m.Identity)
                .SingleOrDefault(m => m.IdentityId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var chats = _context.Chats
                .Include(u => u.Users)
                    .ThenInclude(x => x.User)
                .Where(t => t.Type == ChatType.Private && t.Users
                    .Any(y => y.UserId == member.Id))
                .ToList();

            var rooms = ChatMapper(chats);

            return View(rooms);
        }

        public async  Task<IActionResult> CreatePrivateRoom(long userId)
        {
            var member1 = _context.Members
                .Include(m => m.Identity)
                .SingleOrDefault(m => m.IdentityId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var member2 = _context.Members
                .Include(m => m.Identity)
                .SingleOrDefault(m => m.Id == userId);

            var chat = new Chat
            {
                Name = $"{member1.Identity.UserName}|{member2.Identity.UserName}",
                Type = ChatType.Private
            };

            chat.Users.Add(new ChatUser {
                UserId = member1.Id
            });

            chat.Users.Add(new ChatUser
            {
                UserId = member2.Id
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return RedirectToAction("Chat", new { id = chat.Id});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string PrivateRoomDisplay(string roomName)
        {
            string[] names = roomName.Split("|");
            var currentUser = User.Identity.Name;
            var result = Array.Find(names, element => element != currentUser);
            return result;
        }

        private List<PrivateChatViewModel> ChatMapper(List<Chat> chats)
        {
            var rooms = new List<PrivateChatViewModel>();

            foreach (var item in chats)
            {
                rooms.Add(new PrivateChatViewModel
                {
                    Id = item.Id,
                    Name = PrivateRoomDisplay(item.Name)
                });
            }

            return rooms;
        }
    }
}
