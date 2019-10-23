using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers.Memeber
{
    public class MemberProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //ApplicationUser usr = await GetCurrentUserAsync();
            string a = HttpContext.User.Identity.Name;
            ViewData["user"] = a.ToString();
            var applicationDbContext = _context.Projects.Include(p=>p.ProjectManager)
                .FromSql("select * from dbo.Projects where Id IN (Select ProjectId from dbo.ProjectMembers where MemberId IN (Select Id from dbo.Members where Email = {0} ))",a)
                .ToListAsync();
            return View(await applicationDbContext);
            //return View();
        }

    }
}