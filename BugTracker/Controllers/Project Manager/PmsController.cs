using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers.Project_Manager
{
    public class PmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PmsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //ApplicationUser usr = await GetCurrentUserAsync();
            string a = HttpContext.User.Identity.Name;
            ViewData["user"] = a.ToString();
            var applicationDbContext = _context.Projects.Include(p => p.ProjectManager)
                .FromSql("select * from dbo.Projects where ProjectManagerId IN (Select Id from dbo.ProjectManagers where Email = {0} )", a)
                .ToListAsync();
            return View(await applicationDbContext);
        }
    }
}
