using WSMS.Data;
using WSMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WSMS.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RoomViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var member = _context.Members.SingleOrDefault(m => m.IdentityId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var chats = _context.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == member.Id && x.Chat.Type == ChatType.Room)
                .Select(c => c.Chat)
                .ToList();

            return View(chats);
        }
    }
}
