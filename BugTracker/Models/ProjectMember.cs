using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectMember
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Project Name")]
        public int ProjectId { get; set; }
        [Required]
        [DisplayName("Member Name")]
        public int MemberId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Start Date")]
        public DateTime Assigned { get; set; }
        [Required]
        public string Tusk { get; set; }
        public float Progress { get; set; }
        public Project Project { get; set; }
        public Member Member { get; set; }
    }
}
