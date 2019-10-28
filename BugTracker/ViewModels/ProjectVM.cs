using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Project Manager")]
        public string ProjectManager { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public float Progress { get; set; }
    }
}
