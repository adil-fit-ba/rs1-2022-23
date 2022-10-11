using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul1.Models
{
    public class ProjectTask
    { 
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float? original_estimated_hours { get; set; }
        public float? spent_hours { get; set; }
        public int percent_completed { get; set; }
        public DateTime created_time { get; set; }
       
        public Employee employee { get; set; }
        [ForeignKey(nameof(employee))]
        public int employee_id { get; set; }

        public Project project { get; set; }
        [ForeignKey(nameof(project))]
        public int project_id { get; set; }
    }
}
