using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Bug
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("Member")]
        public int MemberId { get; set; }
        [Required]
        [DisplayName("Project")]
        public int ProjectId { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Report Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReportTime { get; set; }
        [DisplayName("Close Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CloseTime { get; set; }
        public int Severity { get; set; }
        public int Status { get; set; }

        public Project Project { get; set; }
        public Member Member { get; set; }
    }
}
