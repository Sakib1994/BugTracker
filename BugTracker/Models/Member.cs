﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Depertment { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
