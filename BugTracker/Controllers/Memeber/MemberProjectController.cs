using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers.Memeber
{
    [Authorize]
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
            var applicationDbContext = _context.Projects.Include(p => p.ProjectManager)
                .FromSql("select * from dbo.Projects where Id IN (Select ProjectId from dbo.ProjectMembers where MemberId IN (Select Id from dbo.Members where Email = {0} ))", a)
                .ToListAsync();
            return View(await applicationDbContext);
        }
        public IActionResult RunningPro()
        {
            string a = HttpContext.User.Identity.Name;
            List<ProjectVM> ProjectVMs = new List<ProjectVM>();
            ViewData["user"] = a.ToString();
            List<Project> projects = _context.Projects.Include(p=>p.ProjectManager)
                .FromSql("select * from dbo.Projects where Id IN (Select ProjectId from dbo.ProjectMembers where MemberId IN (Select Id from dbo.Members where Email = {0} ))",a)
                .ToList();
            foreach (var project in projects)
            {
                ProjectVM projectVM = new ProjectVM {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = project.StartDate,
                    Deadline = project.Deadline,
                    Progress = project.Progress,
                    ProjectManager = project.ProjectManager.Name
                };
                ProjectVMs.Add(projectVM);
            }
            return Ok(ProjectVMs);
        }
        public async Task<IActionResult> Bugs()
        {
            string a = HttpContext.User.Identity.Name;
            var bugs = await _context.Bugs.Include(b=>b.Project)
                .FromSql("select * from dbo.Bugs where ProjectId IN (Select ProjectId from dbo.ProjectMembers where MemberId IN (Select Id from dbo.Members where Email = {0} ))", a)
                .ToListAsync();
            return View(bugs);
        }
    }
}