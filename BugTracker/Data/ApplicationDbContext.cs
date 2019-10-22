using System;
using System.Collections.Generic;
using System.Text;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Bug> Bugs { get; set; }
    }
}
